namespace Sistema_MVC_Mamani.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Actividad")]
    public partial class Actividad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actividad()
        {
            EvidenciaActividad = new HashSet<EvidenciaActividad>();
        }

        [Key]
        public int actividad_id { get; set; }

        public int semestre_id { get; set; }

        public int criterio_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha { get; set; }

        [StringLength(250)]
        public string urlactividad { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public virtual Criterio Criterio { get; set; }

        public virtual Semestre Semestre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EvidenciaActividad> EvidenciaActividad { get; set; }





        //metodo listar

        public List<Actividad> listar() //retorna una coleccion de resgistro
        {
            var objactividad = new List<Actividad>();

            try
            {

                using (var db = new modelo_sistemas())
                {
                    objactividad = db.Actividad.Include("semestre").Include("criterio").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objactividad;
        }

        //metodo obtener

        public Actividad obtener(int id) //retorna solo un objeto
        {
            var objactividad = new Actividad();

            try
            {
                using (var db = new modelo_sistemas())
                {
                    objactividad = db.Actividad.Include("semestre").Include("criterio").Where(x => x.actividad_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objactividad;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new modelo_sistemas())
                {
                    if (this.actividad_id > 0)
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
