using EduquayAPI.Contracts.V1.Request.Support;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.Support;
using EduquayAPI.DataLayer;
using EduquayAPI.DataLayer.Support;
using EduquayAPI.Models.Support;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EduquayAPI.Services.Support
{
    public class SupportService : ISupportService
    {
        private readonly ISupportData _supportData;
        private readonly ISampleCollectionData _sampleCollectionData;
        private readonly IConfiguration _config;


        public SupportService(ISupportDataFactory supportDataFactory, ISampleCollectionDataFactory sampleCollectionDataFactory, IConfiguration config)
        {
            _supportData = new SupportDataFactory().Create();
            _sampleCollectionData = new SampleCollectionDataFactory().Create();
            _config = config;
        }

        public async Task<CheckRCHResponse> CheckRCHIDExist(string rchId)
        {
            CheckRCHResponse sResponse = new CheckRCHResponse();
            try
            {
                var rchIdDetail = _supportData.FetchRCHIDExists(rchId);
                if (rchIdDetail.Count <= 0)
                {
                    sResponse.status = "true";
                    sResponse.rchExist = false;
                    sResponse.data = null;
                }
                else
                {
                    sResponse.rchValid = true;
                    sResponse.status = "true";
                    sResponse.rchExist = true;
                    sResponse.data = rchIdDetail[0];

                }
                return sResponse;
            }
            catch (Exception e)
            {
                sResponse.status = "false";
                sResponse.message = e.Message;
                return sResponse;
            }
        }

        public async Task<CheckBarcodeResponse> CheckbarcodeExist(string barcodeNo)
        {
            CheckBarcodeResponse sResponse = new CheckBarcodeResponse();
            try
            {
                var barcode = _sampleCollectionData.FetchBarcode(barcodeNo);
                if (barcode.Count <= 0)
                {
                    sResponse.status = "true";
                    sResponse.barcodeExist = false;
                    sResponse.data = null;
                }
                else
                {
                    var barcodeDetail = _supportData.FetchBarcodeExist(barcodeNo);
                    //if (barcodeDetail.barcodeValid == true)
                    //{
                    //    sResponse.barcodeValid = true;
                    //}
                    //else
                    //{
                    //    sResponse.barcodeValid = false;
                    //}
                    sResponse.barcodeValid = true;
                    sResponse.status = "true";
                    sResponse.barcodeExist = true;
                    sResponse.data = barcodeDetail;

                }
                return sResponse;
            }
            catch (Exception e)
            {
                sResponse.status = "false";
                sResponse.message = e.Message;
                return sResponse;
            }
        }

        public List<BarcodeErrorDetail> FetchBarcodeDetailsForErrorCorrection(string barcodeNo)
        {
            var allData = _supportData.FetchBarcodeDetailsForErrorCorrection(barcodeNo);
            return allData;
        }

        public List<BarcodeErrorDetail> FetchErrorBarcodeDetails()
        {
            var allData = _supportData.FetchErrorBarcodeDetails();
            return allData;
        }
        public List<BarcodeErrorDetail> FetchDetailsForRCHCorrection(string input)
        {
            var allData = _supportData.FetchDetailsForRCHCorrection(input);
            return allData;
        }

        public async Task<ServiceResponse> UpdateErrorBarcode(UpdateBarcodeRequest bData)
        {
            ServiceResponse sResponse = new ServiceResponse();
            try
            {
                if (string.IsNullOrEmpty(bData.barcodeNo))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "BarcodeNo is missing";
                    return sResponse;
                }
                else if (string.IsNullOrEmpty(bData.revisedBarcodeNo))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Revised BarcodeNo is missing";
                    return sResponse;
                }
                else if (bData.userId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid UserId";
                    return sResponse;
                }
                else
                {
                    var result = _supportData.UpdateErrorBarcode(bData);
                    if (string.IsNullOrEmpty(result.msg))
                    {
                        sResponse.Status = "false";
                        sResponse.Message = $"Unable to Update the Revised Barcode - {bData.revisedBarcodeNo}";
                        return sResponse;
                    }
                    else
                    {
                        if (result.revisedExistCheck == 1)
                        {
                            EmailTrigger(result.barcodeUpdateCode,1);

                        }
                        else
                        {
                            EmailTrigger(result.barcodeUpdateCode,0);
                        }

                        sResponse.Status = "true";
                        sResponse.Message = result.msg;
                        return sResponse;
                    }
                }
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = e.Message;
                return sResponse;
            }
        }
        public void EmailTrigger(string barcodeUpdateCode,int x)
        {
            var detail = _supportData.FetchUpdatedBarcodeDetails(barcodeUpdateCode);
            if(x==0)
            {
                var subjectId = detail[0].subjectId;
                var subjectName = detail[0].subjectName;
                var anmName = detail[0].anmName;
                var anmMobile = detail[0].anmMobile;
                var anmEmail = detail[0].anmEmail;
                var dcName = detail[0].dcName;
                var dcMobile = detail[0].dcMobile;
                var dcEmail = detail[0].dcEmail;
                var scName = detail[0].scName;
                var scMobile = detail[0].scMobile;
                var scEmail = detail[0].scEmail;
                var oldBarcode = detail[0].oldBarcode;
                var revisedBarcode = detail[0].revisedBarcode;

                var host = _config.GetSection("SMTPDetails").GetSection("host").Value;
                var port = _config.GetSection("SMTPDetails").GetSection("port").Value;
                var uName = _config.GetSection("SMTPDetails").GetSection("username").Value;
                string pwd = _config.GetSection("SMTPDetails").GetSection("pwd").Value;
                string from = _config.GetSection("SMTPDetails").GetSection("from").Value;
                string cc = _config.GetSection("BarcodeUpdationEmail").GetSection("recipients").Value;
                //string recipients = "muthuswamy.sr@carisma-solutions.com.au";   // For Testing Purpose
                string recipients = dcEmail + ", " + scEmail ;
                string subject = _config.GetSection("BarcodeUpdationEmail").GetSection("MailSubject").Value;
                string mailSubject = subject.Replace("#OldBarcodeNo", oldBarcode).Replace("#NewBarcodeNo", revisedBarcode);
                string mailTemplateBody = _config.GetSection("BarcodeUpdationEmail").GetSection("BarcodeBody").Value;
                string mailBody = "";
                mailBody = mailBody + mailTemplateBody.Replace("#OldBarcode", oldBarcode).Replace("#RevisedBarcode", revisedBarcode)
                    .Replace("#DCMobile", dcMobile).Replace("#DCName", dcName).Replace("#ANMMobile", anmMobile).Replace("#ANMName", anmName)
                    .Replace("#SubjectId", subjectId).Replace("#SubjectName", subjectName);
                var mailMessage = new MailMessage(from, recipients, mailSubject, mailBody);
                mailMessage.CC.Add(cc);
                mailMessage.IsBodyHtml = true;
                var client = new SmtpClient(host, int.Parse(port))
                {
                    Credentials = new NetworkCredential(uName, pwd),
                    EnableSsl = true
                };
                client.Send(mailMessage);
            }
            else
            {

                var subjectId1 = detail[0].subjectId;
                var subjectName1 = detail[0].subjectName;
                var anmName1 = detail[0].anmName;
                var anmMobile1 = detail[0].anmMobile;
                var anmEmail1 = detail[0].anmEmail;
                var dcName1 = detail[0].dcName;
                var dcMobile1 = detail[0].dcMobile;
                var dcEmail1 = detail[0].dcEmail;
                var scName1 = detail[0].scName;
                var scMobile1 = detail[0].scMobile;
                var scEmail1 = detail[0].scEmail;
                var oldBarcode1 = detail[0].oldBarcode;
                var revisedBarcode1 = detail[0].revisedBarcode;

                var subjectId2 = detail[1].subjectId;
                var subjectName2 = detail[1].subjectName;
                var anmName2 = detail[1].anmName;
                var anmMobile2 = detail[1].anmMobile;
                var anmEmail2 = detail[1].anmEmail;
                var dcName2 = detail[1].dcName;
                var dcMobile2 = detail[1].dcMobile;
                var dcEmail2 = detail[1].dcEmail;
                var scName2 = detail[1].scName;
                var scMobile2 = detail[1].scMobile;
                var scEmail2 = detail[1].scEmail;
                var oldBarcode2 = detail[1].oldBarcode;
                var revisedBarcode2 = detail[1].revisedBarcode;

                var host = _config.GetSection("SMTPDetails").GetSection("host").Value;
                var port = _config.GetSection("SMTPDetails").GetSection("port").Value;
                var uName = _config.GetSection("SMTPDetails").GetSection("username").Value;
                string pwd = _config.GetSection("SMTPDetails").GetSection("pwd").Value;
                string from = _config.GetSection("SMTPDetails").GetSection("from").Value;
                string cc = _config.GetSection("BarcodeUpdationEmail").GetSection("recipients").Value;
                //string recipients = "muthuswamy.sr@carisma-solutions.com.au";   // For Testing Purpose
                string recipients = dcEmail1  + ", " + scEmail1 + ", " + dcEmail2 ;
                string subject = _config.GetSection("BarcodeUpdationEmail").GetSection("ExistMailSubject").Value;
                string mailSubject = subject.Replace("#OldBarcodeNo1", oldBarcode1).Replace("#NewBarcodeNo1", revisedBarcode1)
                    .Replace("#OldBarcodeNo2", oldBarcode2).Replace("#NewBarcodeNo2", revisedBarcode2);
                string mailTemplateBody = _config.GetSection("BarcodeUpdationEmail").GetSection("ExistBarcodeBody").Value;
                string mailBody = "";
                mailBody = mailBody + mailTemplateBody.Replace("#OldBarcode1", oldBarcode1).Replace("#RevisedBarcode1", revisedBarcode1)
                    .Replace("#DCMobile1", dcMobile1).Replace("#DCName1", dcName1).Replace("#ANMMobile1", anmMobile1).Replace("#ANMName1", anmName1)
                    .Replace("#SubjectId1", subjectId1).Replace("#SubjectName1", subjectName1)
                    .Replace("#OldBarcode2", oldBarcode2).Replace("#RevisedBarcode2", revisedBarcode2)
                    .Replace("#DCMobile2", dcMobile2).Replace("#DCName2", dcName2).Replace("#ANMMobile2", anmMobile2).Replace("#ANMName2", anmName2)
                    .Replace("#SubjectId2", subjectId2).Replace("#SubjectName2", subjectName2);
                var mailMessage = new MailMessage(from, recipients, mailSubject, mailBody);
                mailMessage.CC.Add(cc);
                mailMessage.IsBodyHtml = true;
                var client = new SmtpClient(host, int.Parse(port))
                {
                    Credentials = new NetworkCredential(uName, pwd),
                    EnableSsl = true
                };
                client.Send(mailMessage);
            }
        }

        public async Task<ServiceResponse> UpdateRCHId(UpdateRCHIDRequest rData)
        {
            ServiceResponse sResponse = new ServiceResponse();
            try
            {
                if (string.IsNullOrEmpty(rData.rchId))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "RCHID is missing";
                    return sResponse;
                }
                else if (string.IsNullOrEmpty(rData.revisedRCHID))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Revised RCHID is missing";
                    return sResponse;
                }
                else if (rData.userId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid UserId";
                    return sResponse;
                }
                else
                {
                    var result = _supportData.UpdateRCHId(rData);
                    if (string.IsNullOrEmpty(result.msg))
                    {
                        sResponse.Status = "false";
                        sResponse.Message = $"Unable to Update the Revised RCHID - {rData.revisedRCHID}";
                        return sResponse;
                    }
                    else
                    {
                        if (result.revisedExistCheck == 1)
                        {
                            EmailRCHTrigger(result.rchUpdateCode, 1);

                        }
                        else
                        {
                            EmailRCHTrigger(result.rchUpdateCode, 0);
                        }

                        sResponse.Status = "true";
                        sResponse.Message = result.msg;
                        return sResponse;
                    }
                }
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = e.Message;
                return sResponse;
            }
        }

        public void EmailRCHTrigger(string rchUpdateCode, int x)
        {
            var detail = _supportData.FetchUpdatedRCHIDDetails(rchUpdateCode);
            if (x == 0)
            {
                var subjectId = detail[0].subjectId;
                var subjectName = detail[0].subjectName;
                var anmName = detail[0].anmName;
                var anmMobile = detail[0].anmMobile;
                var anmEmail = detail[0].anmEmail;
                var dcName = detail[0].dcName;
                var dcMobile = detail[0].dcMobile;
                var dcEmail = detail[0].dcEmail;
                var scName = detail[0].scName;
                var scMobile = detail[0].scMobile;
                var scEmail = detail[0].scEmail;
                var oldRCHID = detail[0].oldRCHID;
                var revisedRCHID = detail[0].revisedRCHID;

                var host = _config.GetSection("SMTPDetails").GetSection("host").Value;
                var port = _config.GetSection("SMTPDetails").GetSection("port").Value;
                var uName = _config.GetSection("SMTPDetails").GetSection("username").Value;
                string pwd = _config.GetSection("SMTPDetails").GetSection("pwd").Value;
                string from = _config.GetSection("SMTPDetails").GetSection("from").Value;
                string cc = _config.GetSection("RCHUpdationEmail").GetSection("recipients").Value;
                //string recipients = "muthuswamy.sr@carisma-solutions.com.au";   // For Testing Purpose
                string recipients = dcEmail + ", " + scEmail;
                string subject = _config.GetSection("RCHUpdationEmail").GetSection("MailSubject").Value;
                string mailSubject = subject.Replace("#OldRCHID", oldRCHID).Replace("#NewRCHID", revisedRCHID);
                string mailTemplateBody = _config.GetSection("RCHUpdationEmail").GetSection("RCHBody").Value;
                string mailBody = "";
                mailBody = mailBody + mailTemplateBody.Replace("#OldRCHID", oldRCHID).Replace("#RevisedRCHID", revisedRCHID)
                    .Replace("#DCMobile", dcMobile).Replace("#DCName", dcName).Replace("#ANMMobile", anmMobile).Replace("#ANMName", anmName)
                    .Replace("#SubjectId", subjectId).Replace("#SubjectName", subjectName);
                var mailMessage = new MailMessage(from, recipients, mailSubject, mailBody);
                mailMessage.CC.Add(cc);
                mailMessage.IsBodyHtml = true;
                var client = new SmtpClient(host, int.Parse(port))
                {
                    Credentials = new NetworkCredential(uName, pwd),
                    EnableSsl = true
                };
                client.Send(mailMessage);
            }
            else
            {

                var subjectId1 = detail[0].subjectId;
                var subjectName1 = detail[0].subjectName;
                var anmName1 = detail[0].anmName;
                var anmMobile1 = detail[0].anmMobile;
                var anmEmail1 = detail[0].anmEmail;
                var dcName1 = detail[0].dcName;
                var dcMobile1 = detail[0].dcMobile;
                var dcEmail1 = detail[0].dcEmail;
                var scName1 = detail[0].scName;
                var scMobile1 = detail[0].scMobile;
                var scEmail1 = detail[0].scEmail;
                var oldRCHID1 = detail[0].oldRCHID;
                var revisedRCHID1 = detail[0].revisedRCHID;

                var subjectId2 = detail[1].subjectId;
                var subjectName2 = detail[1].subjectName;
                var anmName2 = detail[1].anmName;
                var anmMobile2 = detail[1].anmMobile;
                var anmEmail2 = detail[1].anmEmail;
                var dcName2 = detail[1].dcName;
                var dcMobile2 = detail[1].dcMobile;
                var dcEmail2 = detail[1].dcEmail;
                var scName2 = detail[1].scName;
                var scMobile2 = detail[1].scMobile;
                var scEmail2 = detail[1].scEmail;
                var oldRCHID2 = detail[1].oldRCHID;
                var revisedRCHID2 = detail[1].revisedRCHID;

                var host = _config.GetSection("SMTPDetails").GetSection("host").Value;
                var port = _config.GetSection("SMTPDetails").GetSection("port").Value;
                var uName = _config.GetSection("SMTPDetails").GetSection("username").Value;
                string pwd = _config.GetSection("SMTPDetails").GetSection("pwd").Value;
                string from = _config.GetSection("SMTPDetails").GetSection("from").Value;
                string cc = _config.GetSection("RCHUpdationEmail").GetSection("recipients").Value;
                //string recipients = "muthuswamy.sr@carisma-solutions.com.au";   // For Testing Purpose
                string recipients = dcEmail1 + ", " + scEmail1 + ", " + dcEmail2;
                string subject = _config.GetSection("RCHUpdationEmail").GetSection("ExistMailSubject").Value;
                string mailSubject = subject.Replace("#OldRCHID1", oldRCHID1).Replace("#NewRCHID1", revisedRCHID1)
                    .Replace("#OldRCHID2", oldRCHID2).Replace("#NewRCHID2", revisedRCHID2);
                string mailTemplateBody = _config.GetSection("RCHUpdationEmail").GetSection("ExistRCHBody").Value;
                string mailBody = "";
                mailBody = mailBody + mailTemplateBody.Replace("#OldRCHID1", oldRCHID1).Replace("#RevisedRCHID1", revisedRCHID1)
                    .Replace("#DCMobile1", dcMobile1).Replace("#DCName1", dcName1).Replace("#ANMMobile1", anmMobile1).Replace("#ANMName1", anmName1)
                    .Replace("#SubjectId1", subjectId1).Replace("#SubjectName1", subjectName1)
                    .Replace("#OldRCHID2", oldRCHID2).Replace("#RevisedRCHID2", revisedRCHID2)
                    .Replace("#DCMobile2", dcMobile2).Replace("#DCName2", dcName2).Replace("#ANMMobile2", anmMobile2).Replace("#ANMName2", anmName2)
                    .Replace("#SubjectId2", subjectId2).Replace("#SubjectName2", subjectName2);
                var mailMessage = new MailMessage(from, recipients, mailSubject, mailBody);
                mailMessage.CC.Add(cc);
                mailMessage.IsBodyHtml = true;
                var client = new SmtpClient(host, int.Parse(port))
                {
                    Credentials = new NetworkCredential(uName, pwd),
                    EnableSsl = true
                };
                client.Send(mailMessage);
            }
        }

      
    } 
}
