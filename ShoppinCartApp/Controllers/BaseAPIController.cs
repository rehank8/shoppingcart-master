using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCartApp.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppinCartApp.Controllers
{
    /// <summary>
    /// The common API controller to perform common CRUD Operations.
    /// </summary>
    /// <typeparam name="TRepo"> TypeRepository </typeparam>
    /// <typeparam name="TGetAll">ViewModel Type for GetAll</typeparam>
    /// <typeparam name="TGet">ViewModel Type for GetById</typeparam>
    /// <typeparam name="TAdd">ViewModel Type for Add</typeparam>
    /// <typeparam name="TUpdate">ViewModel Type for Update</typeparam>

    public class BaseAPIController<TRepo, TGetAll, TGet, TAdd, TUpdate> : ControllerBase
    {
        #region Private Members
        protected IMapper _mapper;
        protected IGenericRepository<TRepo> _repo;
        public BaseAPIController(IMapper mapper, IGenericRepository<TRepo> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        #endregion

        #region methods

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async virtual Task<ActionResult<IList<TGetAll>>> GetAllAsync()
        {
            try
            {
                var data = await _repo.GetAll();

                return Ok(_mapper.Map<IList<TGetAll>>(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async virtual Task<ActionResult<TGet>> GetAysnc([FromRoute] string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    return NotFound();
                }

                var data = await _repo.Find<string>(id);
                return Ok(_mapper.Map<TGet>(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{userid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TAdd>> AddAsync([FromBody] TAdd add, [FromRoute] string userid)
        {
            try
            {
                if (string.IsNullOrEmpty(userid))
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<TRepo>(add);
                    var res = await _repo.Add(data, userid);
                    return Ok(_mapper.Map<TAdd>(res));
                }
                return BadRequest(add);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{entityid}/{userid}/{isdelete}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateAsync([FromBody] TUpdate update, [FromRoute] string entityid, [FromRoute] string userid, [FromRoute] bool isdelete)
        {

            try
            {
                if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(entityid))
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<TRepo>(update);
                    await _repo.Update(data, entityid, userid, isdelete);
                    return NoContent();
                }
                return BadRequest(update);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{entityid}/{userid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> DeleteAsync([FromRoute] string entityid, [FromRoute] string userid)
        {
            try
            {
                await _repo.Delete<string>(entityid, userid);
                return Ok(entityid);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
