namespace Sistema_MVC_Mamani.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Control")]
    public partial class Control
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Control()
        {
            ControlAsignacion = new HashSet<ControlAsignacion>();
        }

        [Key]
        public int control_id { get; set; }

        public int semestre_id { get; set; }

        [Required]
        [StringLength(250)]
        public string titulo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechacreacion { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public virtual Semestre Semestre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ControlAsignacion> ControlAsignacion { get; set; }





        //metodo listar

        public List<Control> listar() //retorna una coleccion de resgistro
        {
            var objcontrol = new List<Control>();

            try
            {

                using (var db = new modelo_sistemas())
                {
                    objcontrol = db.Control.Include("controlasignacion").Include("semestre").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objcontrol;
        }

        //metodo obtener

        public Control obtener(int id) //retorna solo un objeto
        {
            var objcontrol = new Control();

            try
            {
                using (var db = new modelo_sistemas())
                {
                    objcontrol = db.Control.Include("controlasignacion").Include("semestre").Where(x => x.control_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objcontrol;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new modelo_sistemas())
                {
                    if (this.control_id > 0)
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
