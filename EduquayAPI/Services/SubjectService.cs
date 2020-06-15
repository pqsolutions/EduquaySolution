﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;


namespace EduquayAPI.Services
{
    public class SubjectService : ISubjectService
    {

        private readonly ISubjectData _subjectData;

        public SubjectService(ISubjectDataFactory subjectDataFactory)
        {
            _subjectData = new SubjectDataFactory().Create();
        }
        public string AddSubject(SubjectRegistrationRequest subRegData)
        {
            try
            {
                if (subRegData.SubjectPrimaryRequest.DistrictID <= 0)
                {
                    return "Invalid District Id";
                }
                if (subRegData.SubjectPrimaryRequest.CHCID <= 0)
                {
                    return "Invalid CHC Id";
                }
                if (subRegData.SubjectPrimaryRequest.PHCID <= 0)
                {
                    return "Invalid PHC Id";
                }
                if (subRegData.SubjectPrimaryRequest.SCID <= 0)
                {
                    return "Invalid SC Id";
                }
                if (subRegData.SubjectPrimaryRequest.RIID <= 0)
                {
                    return "Invalid RI Id";
                }

                if (subRegData.SubjectPrimaryRequest.IsActive.ToLower() != "true")
                {
                    subRegData.SubjectPrimaryRequest.IsActive = "false";
                }

                var result = _subjectData.AddSubject(subRegData);
                return string.IsNullOrEmpty(result) ? $"Unable to generate subject detail" : result;
            }
            catch (Exception e)
            {
                return $"Unable to generate subject detail - {e.Message}";
            }

        }

        public List<SubjectAddresDetail> RetrieveAddressDetail(string uniqueSubjectId)
        {
            var subjectAddress = _subjectData.RetrieveAddressDetail(uniqueSubjectId);
            return subjectAddress;
        }

        public List<SubjectParentDetail> RetrieveParentDetail(string uniqueSubjectId)
        {
            var subjectParent = _subjectData.RetrieveParentDetail(uniqueSubjectId);
            return subjectParent;
        }

        public List<SubjectPregnancyDetail> RetrievePregnancyDetail(string uniqueSubjectId)
        {
            var subjectPregnancy = _subjectData.RetrievePregnancyDetail(uniqueSubjectId);
            return subjectPregnancy;
        }

        public List<SubjectPrimaryDetail> RetrievePrimaryDetail(string uniqueSubjectId)
        {
            var subjectPrimary = _subjectData.RetrievePrimaryDetail(uniqueSubjectId);
            return subjectPrimary;
        }
    }
}