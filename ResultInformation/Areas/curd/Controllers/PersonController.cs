using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using ResultInformation.DAL;

namespace ResultInformation.Areas
{
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using ResultInformation.DAL;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Person>("Person");
    builder.EntitySet<AcademicHistory>("AcademicHistory"); 
    builder.EntitySet<Registration>("Registration"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PersonController : ODataController
    {
        private SIMSEntities db = new SIMSEntities();

        // GET odata/Person
        [Queryable]
        public IQueryable<Person> GetPerson()
        {
            return db.People;
        }

        // GET odata/Person(5)
        [Queryable]
        public SingleResult<Person> GetPerson([FromODataUri] int key)
        {
            return SingleResult.Create(db.People.Where(person => person.Id == key));
        }

        // PUT odata/Person(5)
        public IHttpActionResult Put([FromODataUri] int key, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != person.Id)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(person);
        }

        // POST odata/Person
        public IHttpActionResult Post(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(person);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PersonExists(person.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(person);
        }

        // PATCH odata/Person(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Person> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Person person = db.People.Find(key);
            if (person == null)
            {
                return NotFound();
            }

            patch.Patch(person);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(person);
        }

        // DELETE odata/Person(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Person person = db.People.Find(key);
            if (person == null)
            {
                return NotFound();
            }

            db.People.Remove(person);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Person(5)/AcademicHistories
        [Queryable]
        public IQueryable<AcademicHistory> GetAcademicHistories([FromODataUri] int key)
        {
            return db.People.Where(m => m.Id == key).SelectMany(m => m.AcademicHistories);
        }

        // GET odata/Person(5)/Person1
        [Queryable]
        public IQueryable<Person> GetPerson1([FromODataUri] int key)
        {
            return db.People.Where(m => m.Id == key).SelectMany(m => m.Person1);
        }

        // GET odata/Person(5)/Person2
        [Queryable]
        public SingleResult<Person> GetPerson2([FromODataUri] int key)
        {
            return SingleResult.Create(db.People.Where(m => m.Id == key).Select(m => m.Person2));
        }

        // GET odata/Person(5)/Registrations
        [Queryable]
        public IQueryable<Registration> GetRegistrations([FromODataUri] int key)
        {
            return db.People.Where(m => m.Id == key).SelectMany(m => m.Registrations);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int key)
        {
            return db.People.Count(e => e.Id == key) > 0;
        }
    }
}
