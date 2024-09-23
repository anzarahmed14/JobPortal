using JobPortal.DTO;
using JobPortal.IRepositories;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class SkillInfoService : ISkillInfoService
    {
        private readonly ISkillInfoRepository _skillInfoRepository;
        public SkillInfoService(ISkillInfoRepository skillInfoRepository) {
            _skillInfoRepository = skillInfoRepository;
        }
        public async Task<IEnumerable<GetSkillInfoDTO>> CreateSkillInfoAsync(IEnumerable<CreateSkillInfoDTO> SkillInfoDTO)
        {

            var createdSkillInfos = SkillInfoDTO.Select(skillInfoDTO =>
                new SkillInfo { SkillId = skillInfoDTO.SkillId, ExpertLevelId = skillInfoDTO.ExpertLevelId, UserId = skillInfoDTO.UserId }).ToList();

            var skillInfo = await _skillInfoRepository.CreateAsync(createdSkillInfos.Where(x=>x.SkillId>0));

            var skillInfoDtos = skillInfo.Select(x => new GetSkillInfoDTO(x.Id,x.SkillId, x.ExpertLevelId));

            return skillInfoDtos;
        }

        public async Task<GetSkillInfoDTO> CreateSkillInfoAsync(CreateSkillInfoDTO skillInfoDTO)
        {
            var skillInfo = await _skillInfoRepository.CreateAsync(new SkillInfo
            {
                SkillId = skillInfoDTO.SkillId,
                UserId = skillInfoDTO.UserId,
                ExpertLevelId = skillInfoDTO.ExpertLevelId
            });

            return new GetSkillInfoDTO(skillInfo.Id, skillInfo.SkillId, skillInfo.ExpertLevelId);
        }

        public async Task<bool> DeleteSkillInfoAsync(long Id)
        {
            try
            {
                var skillInfo = await _skillInfoRepository.GetByIdAsync(Id);
                if (skillInfo == null)
                {
                    throw new Exception($"SkillInfo with ID {Id} not found for delete.");
                }

                return await _skillInfoRepository.DeleteAsync(skillInfo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetSkillInfoDTO>> GetAllSkillInfosAsync()
        {
            try
            {
                var skillInfos = await _skillInfoRepository.GetAllAsync();

                var skillInfosDTO = skillInfos.Select(s => new GetSkillInfoDTO(s.Id, s.SkillId, s.ExpertLevelId));
               

                return skillInfosDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetSkillInfoDTO> GetSkillInfoByIdAsync(long Id)
        {
            try
            {
                var skill = await _skillInfoRepository.GetByIdAsync(Id);

                var skillDTO = new GetSkillInfoDTO(skill.Id, skill.SkillId, skill.ExpertLevelId);
               

                return skillDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

    

        public async Task<GetSkillInfoDTO> UpdateSkillInfoAsync(long Id, UpdateSkillInfoDTO SkillInfoDTO)
        {
            try
            {
                var skill = await _skillInfoRepository.GetByIdAsync(Id);
                if (skill == null)
                {
                    throw new Exception($"Slill Info with ID {Id} not found for update.");
                }

                skill.SkillId = SkillInfoDTO.SkillId;
                skill.ExpertLevelId = SkillInfoDTO.ExpertLevelId;

                var updatedCity = await _skillInfoRepository.UpdateAsync(skill);

                var skillDTO = new GetSkillInfoDTO(skill.Id, skill.SkillId, skill.ExpertLevelId);

                return skillDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

       

       public async Task<IEnumerable<GetSkillInfoDTOs>> GetSkillInfosByUserIdAsync(long userId)
        {
            var skillInfos = await _skillInfoRepository.GetSkillInfosByUserIdAsync(userId);

            var skillInfoDTOs = skillInfos.Select(skill => (new GetSkillInfoDTOs(skill.Id, skill.SkillId,skill.ExpertLevelId,skill.ExportLevel.ExportLevelName, skill.Skill.SkillName)));

            return skillInfoDTOs;
        }
    }
}
