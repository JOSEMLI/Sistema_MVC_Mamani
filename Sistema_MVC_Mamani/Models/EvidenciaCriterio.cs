namespace Sistema_MVC_Mamani.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("EvidenciaCriterio")]
    public partial class EvidenciaCriterio
    {
        [Key]
        public int evidencia_id { get; set; }

        public int criterio_id { get; set; }

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

        public virtual Criterio Criterio { get; set; }





        //metodo listar

        public List<EvidenciaCriterio> listar() //retorna una coleccion de resgistro
        {
            var objevidenciacriterio = new List<EvidenciaCriterio>();

            try
            {

                using (var db = new modelo_sistemas())
                {
                    objevidenciacriterio = db.EvidenciaCriterio.Include("criterio").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objevidenciacriterio;
        }

        //metodo obtener

        public EvidenciaCriterio obtener(int id) //retorna solo un objeto
        {
            var objevidenciacriterio = new EvidenciaCriterio();

            try
            {
                using (var db = new modelo_sistemas())
                {
                    objevidenciacriterio = db.EvidenciaCriterio.Include("criterio").Where(x => x.evidencia_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objevidenciacriterio;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new modelo_sistemas())
                {
                    if (this.evidencia_id > 0)
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
