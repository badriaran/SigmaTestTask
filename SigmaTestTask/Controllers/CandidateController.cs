using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SigmaTestTask.Data;
using SigmaTestTask.Models;
using SigmaTestTask.Models.Entities;

namespace SigmaTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CandidateController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllCandidates()
        {
            var allCandidates= dbContext.Candidates.ToList();
            return Ok(allCandidates);   
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetCandidateById(Guid id)
        {
            var candidate=dbContext.Candidates.Find(id);
            if(candidate is null)
            {
                return NotFound();
            }
            return Ok(candidate);
        }
        [HttpPost]
        public IActionResult AddCandidate(AddCandidateDto addCandidateDto)
        {
            var candidate = new Candidate()
            {
                Email = addCandidateDto.Email,
                FirstName = addCandidateDto.FirstName,
                LastName = addCandidateDto.LastName,
                PhoneNumber = addCandidateDto.PhoneNumber,
                PreferredCallTime = addCandidateDto.PreferredCallTime,
                LinkedInProfile = addCandidateDto.LinkedInProfile,
                GitHubProfile = addCandidateDto.GitHubProfile,
                Comments = addCandidateDto.Comments
            };
            dbContext.Candidates.Add(candidate);
            dbContext.SaveChanges();
            return Ok(candidate);

        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCandidate(int id,UpdateCandidateDto updateCandidateDto )
        {
            var candidate = dbContext.Candidates.Find(id);
            if (candidate is null)
            {
                return NotFound();
            }
            candidate.FirstName = updateCandidateDto.FirstName;
            candidate.LastName = updateCandidateDto.LastName;
            candidate.PhoneNumber = updateCandidateDto.PhoneNumber;
            candidate.PreferredCallTime = updateCandidateDto.PreferredCallTime;
            candidate.LinkedInProfile = updateCandidateDto.LinkedInProfile;
            candidate.GitHubProfile = updateCandidateDto.GitHubProfile;
            candidate.Comments = updateCandidateDto.Comments;
            dbContext.SaveChanges();
            return Ok(candidate);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCandidate(int id)
        {
            var candidate = dbContext.Candidates.Find(id);
            if (candidate is null)
            {
                return NotFound();
            }
            dbContext.Candidates.Remove(candidate);
            dbContext.SaveChanges(); 
            return Ok();
        }
    }
}
