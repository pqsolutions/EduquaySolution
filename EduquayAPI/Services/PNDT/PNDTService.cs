using EduquayAPI.Contracts.V1.Request.PNDTC;
using EduquayAPI.Contracts.V1.Response.PNDT;
using EduquayAPI.DataLayer.PNDT;
using EduquayAPI.Models.PNDT;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;

namespace EduquayAPI.Services.PNDT
{
    public class PNDTService : IPNDTService
    {

        private readonly IPNDTData _pndtData;
        public readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _config;


        public PNDTService(IPNDTDataFactory pndtData, IHostingEnvironment hostingEnvironment, IConfiguration config)
        {
            _pndtData = new PNDTDataFactory().Create();
            _hostingEnvironment = hostingEnvironment;
            _config = config;
        }



        public async Task<AddCounsellingResponse> AddCounselling(AddPrePNDTCounsellingRequest acData)
        {
            var sResponse = new AddCounsellingResponse();
            try
            {
                //var extension = "";
                // var fileNames = "";
                // var fullPath = "";
                // if (acData.isPNDTAgreeYes == true)
                // {
                //     if (formFile.FileName != null || formFile.FileName != "")
                //     {
                //         extension = "." + formFile.FileName.Split('.')[formFile.FileName.Split('.').Length - 1];
                //         fileNames = DateTime.Now.Ticks + "_" + formFile.FileName; //Create a new Name for the file due to security reasons.

                //         if (formFile.Length > 0)
                //         {
                //            // full path to file in location
                //            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "PrePNDTForm");

                //             if (!Directory.Exists(filePath))
                //             {
                //                 Directory.CreateDirectory(filePath);
                //             }
                //             using (var stream = new FileStream(fullPath, FileMode.Create))
                //             {
                //                 formFile.CopyTo(stream);
                //             }
                //         }
                //     }
                //     else
                //     {
                //         sResponse.Status = "false";
                //         sResponse.Message = $"File is missing";
                //         return sResponse;
                //     }
                // }

                var schedulingDateTime = _pndtData.AddCounselling(acData);
                sResponse.Status = "true";
                sResponse.Message = string.Empty;
                sResponse.data = schedulingDateTime;
                return sResponse;
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to add counselling - {e.Message}";
                return sResponse;
            }

        }

        public async Task<FileResponse> GetPostPNDTFileDetails(IFormFile formData)
        {
            var sResponse = new FileResponse();
            var fd = new FileDetails();

            var extension = "";
            var fileNames = "";
            var fullPath = "";
            var postPNDTFileLocation = _config.GetSection("Key").GetSection("PostPNDTFileFolder").Value;
            if (formData.FileName != null || formData.FileName != "")
            {
                extension = "." + formData.FileName.Split('.')[formData.FileName.Split('.').Length - 1];
                fileNames = DateTime.Now.Ticks + "_" + formData.FileName; //Create a new Name for the file due to security reasons.                      
                if (formData.Length > 0)
                {
                    // HostingEnvironment.MapPath(ConfigurationManager.AppSettings["fileUploadFolder"])

                    if (!Directory.Exists(_hostingEnvironment.WebRootPath + postPNDTFileLocation))
                    {
                        Directory.CreateDirectory(_hostingEnvironment.WebRootPath + postPNDTFileLocation);
                    }


                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath + postPNDTFileLocation);
                    fullPath = Path.Combine(filePath, fileNames);

                    using (FileStream stream = File.Create(_hostingEnvironment.WebRootPath + postPNDTFileLocation + fileNames))
                    {
                        await formData.CopyToAsync(stream);
                        stream.Flush();
                    }
                    // full path to file in location
                    // var filePath = Path.Combine(Directory.GetCurrentDirectory(), "MTPForm");
                    //if (!Directory.Exists(filePath))
                    //{
                    //    Directory.CreateDirectory(filePath);
                    //}
                    //using (var stream = new FileStream(fullPath, FileMode.Create))
                    //{
                    //    formData.CopyTo(stream);
                    //}
                }
                fd.fileName = fileNames;
                fd.fileLocation = fullPath;
                sResponse.Status = "true";
                sResponse.Message = string.Empty;
                sResponse.data = fd;
            }
            else
            {
                sResponse.Status = "false";
                sResponse.Message = $"File is missing";
            }
            return sResponse;
        }
        public async Task<FileResponse> GetPrePNDTFileDetails(IFormFile formData)
        {
            var sResponse = new FileResponse();
            var fd = new FileDetails();
            var extension = "";
            var fileNames = "";
            var fullPath = "";
            var prePNDTFileLocation = _config.GetSection("Key").GetSection("PrePNDTFileFolder").Value;
            if (formData.FileName != null || formData.FileName != "")
            {
                extension = "." + formData.FileName.Split('.')[formData.FileName.Split('.').Length - 1];
                fileNames = DateTime.Now.Ticks + "_" + formData.FileName; //Create a new Name for the file due to security reasons.                      
                if (formData.Length > 0)
                {

                    if (!Directory.Exists(_hostingEnvironment.WebRootPath + prePNDTFileLocation))
                    {
                        Directory.CreateDirectory(_hostingEnvironment.WebRootPath + prePNDTFileLocation);
                    }
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath + prePNDTFileLocation);
                    fullPath = Path.Combine(filePath, fileNames);

                    using (FileStream stream = File.Create(_hostingEnvironment.WebRootPath + prePNDTFileLocation + fileNames))
                    {
                        await formData.CopyToAsync(stream);
                        stream.Flush();
                    }

                    //// full path to file in location
                    //var filePath = Path.Combine(Directory.GetCurrentDirectory(), "PNDTForm");
                    //if (!Directory.Exists(filePath))
                    //{
                    //    Directory.CreateDirectory(filePath);
                    //}
                    //fullPath = Path.Combine(filePath, fileNames);
                    //using (var stream = new FileStream(fullPath, FileMode.Create))
                    //{
                    //    formData.CopyTo(stream);
                    //}
                }
                fd.fileName = fileNames;
                fd.fileLocation = fullPath;
                sResponse.Status = "true";
                sResponse.Message = string.Empty;
                sResponse.data = fd;
            }
            else
            {
                sResponse.Status = "false";
                sResponse.Message = $"File is missing";
            }
            return sResponse;
        }

        public async Task<AddPostCounsellingResponse> AddPostPNDTCounselling(AddPostPNDTCounsellingRequest acData)
        {
            var sResponse = new AddPostCounsellingResponse();
            try
            {
                //var extension = "";
                //var fileNames = "";
                //var fullPath = "";
                //if (acData.isMTPAgreeYes == true)
                //{
                //    if (formFile.FileName != null || formFile.FileName != "")
                //    {
                //        extension = "." + formFile.FileName.Split('.')[formFile.FileName.Split('.').Length - 1];
                //        fileNames = DateTime.Now.Ticks + "_" + formFile.FileName; //Create a new Name for the file due to security reasons.                      
                //        if (formFile.Length > 0)
                //        {
                //            // full path to file in location
                //            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "MTPForm");
                //            if (!Directory.Exists(filePath))
                //            {
                //                Directory.CreateDirectory(filePath);
                //            }
                //            fullPath = Path.Combine(filePath, fileNames);
                //            using (var stream = new FileStream(fullPath, FileMode.Create))
                //            {
                //                formFile.CopyTo(stream);
                //            }
                //        }
                //    }
                //    else
                //    {
                //        sResponse.Status = "false";
                //        sResponse.Message = $"File is missing";
                //        return sResponse;
                //    }
                //}

                var schedulingDateTime = _pndtData.AddPostPNDTCounselling(acData);
                sResponse.Status = "true";
                sResponse.Message = string.Empty;
                sResponse.data = schedulingDateTime;
                return sResponse;
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to add counselling - {e.Message}";
                return sResponse;
            }
        }

        public async Task<AddSchedulingResponse> AddPostPNDTScheduling(AddSchedulingRequest asData)
        {
            var sResponse = new AddSchedulingResponse();
            try
            {
                if (string.IsNullOrEmpty(asData.counsellingDateTime))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Counselling date and time is missing";
                    return sResponse;
                }
                else if (asData.counsellorId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid counsellor Id";
                    return sResponse;
                }
                else
                {
                    var counsellingDate = _pndtData.AddPostPNDTScheduling(asData);
                    sResponse.Status = "true";
                    sResponse.Message = string.Empty;
                    sResponse.data = counsellingDate;
                    return sResponse;
                }
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to add scheduling - {e.Message}";
                return sResponse;
            }
        }

        public async Task<AddSchedulingResponse> AddScheduling(AddSchedulingRequest asData)
        {
            var sResponse = new AddSchedulingResponse();
            try
            {
                if (string.IsNullOrEmpty(asData.counsellingDateTime))
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Counselling date and time is missing";
                    return sResponse;
                }
                else if (asData.counsellorId <= 0)
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Invalid counsellor Id";
                    return sResponse;
                }
                else
                {
                    var counsellingDate = _pndtData.AddScheduling(asData);
                    sResponse.Status = "true";
                    sResponse.Message = string.Empty;
                    sResponse.data = counsellingDate;
                    return sResponse;
                }
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = $"Unable to add scheduling - {e.Message}";
                return sResponse;
            }
        }

        public List<PrePNDTScheduling> GetPositiveSubjectsScheduling(PNDTSchedulingRequest psData)
        {
            var schedulingData = _pndtData.GetPositiveSubjectsScheduling(psData);
            return schedulingData;
        }



        public List<PostPNDTScheduling> GetPostPNDTScheduling(PNDTSchedulingRequest psData)
        {
            var schedulingData = _pndtData.GetPostPNDTScheduling(psData);
            return schedulingData;
        }
        public List<PrePNDTCounselling> GetScheduledForCounselling(PNDTSchedulingRequest psData)
        {
            _pndtData.AutomaticPrePNDTCousellingUpdate();
            var counsellingData = _pndtData.GetScheduledForCounselling(psData);
            return counsellingData;
        }

        public List<PostPNDTCounselling> GetScheduledForPostPNDTCounselling(PNDTSchedulingRequest psData)
        {
            _pndtData.AutomaticPostPNDTCousellingUpdate();
            var counsellingData = _pndtData.GetScheduledForPostPNDTCounselling(psData);
            return counsellingData;
        }

        public List<PrePNDTCounselled> GetSubjectsCounselledNo(PNDTSchedulingRequest pcData)
        {
            var counseledNoData = _pndtData.GetSubjectsCounselledNo(pcData);
            return counseledNoData;
        }

        public List<PrePNDTCounselled> GetSubjectsCounselledPending(PNDTSchedulingRequest pcData)
        {
            var counseledPendingData = _pndtData.GetSubjectsCounselledPending(pcData);
            return counseledPendingData;
        }

        public List<PrePNDTCounselled> GetSubjectsCounselledYes(PNDTSchedulingRequest pcData)
        {
            var counseledYesData = _pndtData.GetSubjectsCounselledYes(pcData);
            return counseledYesData;
        }

        public List<PostPNDTCounselled> GetSubjectsPostPNDTCounselledNo(PNDTSchedulingRequest pcData)
        {
            var counseledNoData = _pndtData.GetSubjectsPostPNDTCounselledNo(pcData);
            return counseledNoData;
        }

        public List<PostPNDTCounselled> GetSubjectsPostPNDTCounselledPending(PNDTSchedulingRequest pcData)
        {
            var counseledNoData = _pndtData.GetSubjectsPostPNDTCounselledPending(pcData);
            return counseledNoData;
        }

        public List<PostPNDTCounselled> GetSubjectsPostPNDTCounselledYes(PNDTSchedulingRequest pcData)
        {
            var counseledNoData = _pndtData.GetSubjectsPostPNDTCounselledYes(pcData);
            return counseledNoData;
        }

        public List<PostPNDTScheduled> GetSubjectsPostPNDTScheduled(PNDTSchedulingRequest psData)
        {
            var scheduledData = _pndtData.GetSubjectsPostPNDTScheduled(psData);
            return scheduledData;
        }

        public List<PrePNDTScheduled> GetSubjectsScheduled(PNDTSchedulingRequest psData)
        {
            var scheduledData = _pndtData.GetSubjectsScheduled(psData);
            return scheduledData;
        }

    }
}
