using System;
using System.Collections.Generic;
using POC_CRUDFamily.App;

namespace POC_CRUDFamily.Users
{
    public abstract class User : CRUD
    {
        //constructor defaul
        public User() : base("users")
        {

        }

        //attribs
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string MotherLastname { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Residential { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public bool create()
        {
            bool res = false;
            //creamos lista de DataCollection con los datos a insertar de ESTE USUARIO
            List<DataCollection> data = new List<DataCollection>();
            //llenamos con los datos de los campos
            data.Add(new DataCollection("name", Types.VARCHAR, this.Name));
            data.Add(new DataCollection("lastname", Types.VARCHAR, this.Lastname));
            data.Add(new DataCollection("motherlastname", Types.VARCHAR, this.MotherLastname));
            data.Add(new DataCollection("cellphone", Types.VARCHAR, this.Cellphone));
            data.Add(new DataCollection("email", Types.VARCHAR, this.Email));
            data.Add(new DataCollection("street", Types.VARCHAR, this.Street));
            data.Add(new DataCollection("house_number", Types.VARCHAR, this.HouseNumber));
            data.Add(new DataCollection("residential", Types.VARCHAR, this.Residential));
            data.Add(new DataCollection("city", Types.VARCHAR, this.City));
            data.Add(new DataCollection("postal_code", Types.VARCHAR, this.PostalCode));
            //lo pasamos al methosdo create y liston!!
            res = base.create(data);
            return res;
        }

        /// <summary>
        /// Este método permite modificar los campos de un User Admi no Cashier.
        /// El ID tiene que pasarse al OBJETO por su contructor o su SETER!!!! (int Id {get; set;})
        /// </summary>
        /// <returns></returns>
        public bool update()
        {
            //vamos a crear la lista de los datos a modificar
            //creamos lista de DataCollection con los datos a insertar de ESTE USUARIO
            List<DataCollection> data = new List<DataCollection>();
            //llenamos con los datos de los campos
            data.Add(new DataCollection("name", Types.VARCHAR, this.Name));
            data.Add(new DataCollection("lastname", Types.VARCHAR, this.Lastname));
            data.Add(new DataCollection("motherlastname", Types.VARCHAR, this.MotherLastname));
            data.Add(new DataCollection("cellphone", Types.VARCHAR, this.Cellphone));
            data.Add(new DataCollection("email", Types.VARCHAR, this.Email));
            data.Add(new DataCollection("street", Types.VARCHAR, this.Street));
            data.Add(new DataCollection("house_number", Types.VARCHAR, this.HouseNumber));
            data.Add(new DataCollection("residential", Types.VARCHAR, this.Residential));
            data.Add(new DataCollection("city", Types.VARCHAR, this.City));
            data.Add(new DataCollection("postal_code", Types.VARCHAR, this.PostalCode));

            //el ID lo tomamos edel gettter
            int id = this.Id;
            //ejecutamos el updtae y devolvemos el resultado
            return base.update(data, id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool delete()
        {
            return base.delete(this.Id);
        }

        public List<object> read(List<SearchCollection> search )
        {
            return base.read(search);

        }

        public List<object> index( )
        {
            return base.index();
        }
    }
}
