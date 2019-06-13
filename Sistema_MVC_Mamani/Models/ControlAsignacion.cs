namespace Sistema_MVC_Mamani.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("ControlAsignacion")]
    public partial class ControlAsignacion
    {
        [Key]
        public int controlasignacion_id { get; set; }

        public int control_id { get; set; }

        public int docente_id { get; set; }

        public int criterio_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaasignacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaculminacion { get; set; }

        [StringLength(30)]
        public string duracion { get; set; }

        [Required]
        [StringLength(2)]
        public string sustento { get; set; }

        [Required]
        [StringLength(4)]
        public string porcentaje { get; set; }

        [Required]
        [StringLength(30)]
        public string condicion { get; set; }

        [Required]
        [StringLength(250)]
        public string archivo { get; set; }

        [Column(TypeName = "text")]
        public string observacion { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual Control Control { get; set; }

        public virtual Criterio Criterio { get; set; }

        public virtual Docente Docente { get; set; }




        //metodo listar

        public List<ControlAsignacion> listar() //retorna una coleccion de resgistro
        {
            var objcontrolasignacion = new List<ControlAsignacion>();

            try
            {

                using (var db = new modelo_sistemas())
                {
                    objcontrolasignacion = db.ControlAsignacion.Include("control").Include("docente").Include("criterio").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objcontrolasignacion;
        }

        //metodo obtener

        public ControlAsignacion obtener(int id) //retorna solo un objeto
        {
            var objcontrolasignacion = new ControlAsignacion();

            try
            {
                using (var db = new modelo_sistemas())
                {
                    objcontrolasignacion = db.ControlAsignacion.Include("control").Include("docente").Include("criterio").Where(x => x.controlasignacion_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objcontrolasignacion;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new modelo_sistemas())
                {
                    if (this.controlasignacion_id > 0)
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
