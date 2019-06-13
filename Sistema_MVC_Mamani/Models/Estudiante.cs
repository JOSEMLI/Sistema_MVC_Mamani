namespace Sistema_MVC_Mamani.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Estudiante")]
    public partial class Estudiante
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int estudiante_id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int estudiante_codigo { get; set; }

        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [Required]
        [StringLength(100)]
        public string apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(1)]
        public string sexo { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(250)]
        public string direccion { get; set; }

        [StringLength(15)]
        public string celular { get; set; }

        [StringLength(250)]
        public string foto { get; set; }

        [StringLength(1)]
        public string estado { get; set; }




        //metodo listar

        public List<Estudiante> listar() //retorna una coleccion de resgistro
        {
            var objestudiante = new List<Estudiante>();

            try
            {

                using (var db = new modelo_sistemas())
                {
                    objestudiante = db.Estudiante.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objestudiante;
        }

        //metodo obtener

        public Estudiante obtener(int id) //retorna solo un objeto
        {
            var objestudiante = new Estudiante();

            try
            {
                using (var db = new modelo_sistemas())
                {
                    objestudiante = db.Estudiante.Where(x => x.estudiante_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objestudiante;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new modelo_sistemas())
                {
                    if (this.estudiante_id > 0)
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
