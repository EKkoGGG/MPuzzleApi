﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MPuzzleApi.Models;
using Newtonsoft.Json;

namespace MPuzzleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly StoryContext _context;

        public StoryController(StoryContext context)
        {
            _context = context;
        }


        [HttpGet("Title")]
        public async Task<IActionResult> GetStoryTitleAsync()
        {
            List<Story> story = await _context.Story.ToListAsync();
            return new JsonResult(
                 story.Select(t => new
                {
                    t.Id,
                    t.Title
                 })
            );
        }


        // GET: api/Story
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Story>>> GetStory()
        {
            return await _context.Story.ToListAsync();
        }

        // GET: api/Story/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Story>> GetStory(int id)
        {
            var story = await _context.Story.FindAsync(id);

            if (story == null)
            {
                return NotFound();
            }

            return story;
        }

        private bool StoryExists(int id)
        {
            return _context.Story.Any(e => e.Id == id);
        }

        #region 屏蔽其他请求

        //// PUT: api/Story/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutStory(int id, Story story)
        //{
        //    if (id != story.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(story).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StoryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Story
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Story>> PostStory(Story story)
        //{
        //    _context.Story.Add(story);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetStory", new { id = story.Id }, story);
        //}

        //// DELETE: api/Story/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Story>> DeleteStory(int id)
        //{
        //    var story = await _context.Story.FindAsync(id);
        //    if (story == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Story.Remove(story);
        //    await _context.SaveChangesAsync();

        //    return story;
        //}

        #endregion

    }
}
