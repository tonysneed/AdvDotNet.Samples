﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;
using KatanaTokenAuth.RelyingParty.Models;

namespace KatanaTokenAuth.RelyingParty.Controllers
{
    [Authorize] // Require authentication
    public class ClaimsController : ApiController
    {
        // GET: api/claims
        [HostAuthentication("Bearer")] // Use bearer auth
        [ResponseType(typeof(IEnumerable<ClaimInfo>))]
        public IHttpActionResult Get()
        {
            // Cast user to claims principle
            var principle = User as ClaimsPrincipal;
            if (principle == null) return Ok();

            // Return claims
            var claims = principle.Claims.Select
                (c => new ClaimInfo {Type = c.Type, Value = c.Value});
            return Ok(claims);
        }
    }
}
