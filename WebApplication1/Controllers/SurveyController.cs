using Business.Contracts;
using Business.Implementation;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{

    [RoutePrefix("survey")]
    public class SurveyController : ApiController
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService surveyService)
        {

            _surveyService = surveyService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] Survey survey)
        {
            if (survey == null) return BadRequest("Request is null");
            int id = _surveyService.Add(survey);
            if (id < 0) return BadRequest("Unable to Create User");
            var payload = new { Id = id };
            return Ok(payload);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            bool deleted = _surveyService.Delete(id);
            if (!deleted) return NotFound();
            return Ok();
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Survey survey = _surveyService.Get(id);
            if (survey == null) return NotFound();
            return Ok(survey);
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] Survey survey)
        {
            if (survey == null) return BadRequest("Request is null");
            survey.Id = id;
            bool updated = _surveyService.Update(survey);
            if (!updated) return BadRequest("Unable to update User");
            return Ok(survey);
        }

    }
}


