namespace Sistema_MVC_Mamani.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("EvidenciaActividad")]
    public partial class EvidenciaActividad
    {
        [Key]
        public int evidenciaactividad_id { get; set; }

        public int actividad_id { get; set; }

        [Required]
        [StringLength(250)]
        public string archivo { get; set; }

        [Required]
        [StringLength(10)]
        public string tamanio { get; set; }

        [Required]
        [StringLength(10)]
        public string tipo { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        public virtual Actividad Actividad { get; set; }





        //metodo listar

        public List<EvidenciaActividad> listar() //retorna una coleccion de resgistro
        {
            var objevidenciaactividad = new List<EvidenciaActividad>();

            try
            {

                using (var db = new modelo_sistemas())
                {
                    objevidenciaactividad = db.EvidenciaActividad.Include("actividad").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objevidenciaactividad;
        }

        //metodo obtener

        public EvidenciaActividad obtener(int id) //retorna solo un objeto
        {
            var objevidenciaactividad = new EvidenciaActividad();

            try
            {
                using (var db = new modelo_sistemas())
                {
                    objevidenciaactividad = db.EvidenciaActividad.Include("actividad").Where(x => x.evidenciaactividad_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objevidenciaactividad;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new modelo_sistemas())
                {
                    if (this.evidenciaactividad_id > 0)
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
