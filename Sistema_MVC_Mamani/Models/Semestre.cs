namespace Sistema_MVC_Mamani.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Semestre")]
    public partial class Semestre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Semestre()
        {
            Actividad = new HashSet<Actividad>();
            Asignacion = new HashSet<Asignacion>();
            Control = new HashSet<Control>();
        }

        [Key]
        public int semestre_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        public int? anio { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actividad> Actividad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asignacion> Asignacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Control> Control { get; set; }




        //metodo listar

        public List<Semestre> listar() //retorna una coleccion de resgistro
        {
            var objsemestre = new List<Semestre>();

            try
            {

                using (var db = new modelo_sistemas())
                {
                    objsemestre = db.Semestre.Include("asignacion").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objsemestre;
        }

        //metodo obtener

        public Semestre obtener(int id) //retorna solo un objeto
        {
            var objsemestre = new Semestre();

            try
            {
                using (var db = new modelo_sistemas())
                {
                    objsemestre = db.Semestre.Include("asignacion").Where(x => x.semestre_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objsemestre;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new modelo_sistemas())
                {
                    if (this.semestre_id > 0)
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
