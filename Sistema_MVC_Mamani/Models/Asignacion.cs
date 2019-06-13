namespace Sistema_MVC_Mamani.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Asignacion")]
    public partial class Asignacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asignacion()
        {
            DetalleAsignacion = new HashSet<DetalleAsignacion>();
        }

        [Key]
        public int asignacion_id { get; set; }

        public int semestre_id { get; set; }

        [Required]
        [StringLength(250)]
        public string titulo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecharegistro { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public virtual Semestre Semestre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleAsignacion> DetalleAsignacion { get; set; }



        //metodo listar

        public List<Asignacion> listar() //retorna una coleccion de resgistro
        {
            var objasignacion = new List<Asignacion>();

            try
            {

                using (var db = new modelo_sistemas())
                {
                    objasignacion = db.Asignacion.Include("detalleasignacion").Include("semestre").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objasignacion;
        }

        //metodo obtener

        public Asignacion obtener(int id) //retorna solo un objeto
        {
            var objasignacion = new Asignacion();

            try
            {
                using (var db = new modelo_sistemas())
                {
                    objasignacion = db.Asignacion.Include("detalleasignacion").Include("semestre").Where(x => x.asignacion_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objasignacion;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new modelo_sistemas())
                {
                    if (this.asignacion_id > 0)
                    {
                        //si existe un valor mayor a cero es porque exiiste el registro
                        db.Entry(this).State = EntityState.Modified;

                    }
                    else
                    {
                        //si no existe el registro lo graba(nuevo)
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //metodo eliminar

        public void eliminar()
        {
            try
            {
                using (var db = new modelo_sistemas())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}
