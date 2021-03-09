using System;
using System.Collections.Generic;
using POC_CRUDFamily.App;
using POC_CRUDFamily.Users;

namespace POC_CRUDFamily
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("conectando y haciendo INSERT a SQLSERVER");
            //instancia de CRUD
            CRUD crud = new CRUD("products");
            //creamos lista de DataCollection
            //con estos datos:
            //'lata coca cola','lata coca cola 300ml sin azucar', 20.50, '7505484542517'
            List<DataCollection> datosParainsert = new List<DataCollection>();

            datosParainsert.Add(new DataCollection("name", Types.NVARCHAR, "Pq tort. maiz 1kg"));
            datosParainsert.Add(new DataCollection("description", Types.NVARCHAR, "Paquete de 1 kg de tortillas de maiz, en una bolsa."));
            datosParainsert.Add(new DataCollection("price", Types.MONEY, 20));
            datosParainsert.Add(new DataCollection("bar_code", Types.NVARCHAR, "123123123"));

            //ejecutar el iinsert mediante el metodo CREATE
            bool resDeInsertar = crud.create(datosParainsert);

            if (resDeInsertar)
                Console.WriteLine("Si se insertó correctamente el registro");
            else
                Console.WriteLine($"ERROR {CRUD.ERROR}, no se insertó correctamente el registro");



            //'lata coca cola','lata coca cola 300ml sin azucar', 20.50, '7505484542517'
            List<DataCollection> datosParaUpdate = new List<DataCollection>();

            datosParaUpdate.Add(new DataCollection("name", Types.NVARCHAR, "Doritos Pizzerolas 300 gr"));
            datosParaUpdate.Add(new DataCollection("description", Types.NVARCHAR, "Bolsa con 1kg de aire y 300gr de pizzerolas."));
            datosParaUpdate.Add(new DataCollection("price", Types.MONEY, 40.10));
            datosParaUpdate.Add(new DataCollection("bar_code", Types.NVARCHAR, "333333333333333"));

            //ejecutar el iinsert mediante el metodo CREATE
            bool resDeUpdate = crud.update(datosParaUpdate,4);

            if (resDeInsertar)
                Console.WriteLine("Si se modificó correctamente el registro");
            else
                Console.WriteLine($"ERROR {CRUD.ERROR}, no se modificó correctamente el registro");

            ////////////////////////////////////////////////////////
            ///borrar
            if(crud.delete(5)) 
                Console.WriteLine("Si se borró correctamente el registro");
            else
                Console.WriteLine($"ERROR {CRUD.ERROR}, no se borró correctamente el registro");


            ////////////////////////
            ///consultar
            List<SearchCollection> busqueda = new List<SearchCollection>();
            busqueda.Add(new SearchCollection("name", CriteriaOperator.EQUALS, "Vita 100ml",true,  LogicOperator.NADA));

            List<object> resultados  = crud.read(busqueda);

            foreach (object registro in resultados)
            {
                //hacemos casting entre object y string[]
                string[] registroResultante = (string[])registro;
                //imprimir los datos
                foreach (string campo in registroResultante)
                {
                    Console.WriteLine("Campo= "+campo);
                }
                Console.WriteLine("registro---------------------------------------------");
            }

            Console.WriteLine("Todos los registros---------------------------------------------");
            ////////////////////////
            ///index es consultar TODOS los registros de la TABLA

            List<object> todosLosRegistros = crud.index();

            foreach (object prod in todosLosRegistros)
            {
                //hacemos casting entre object y string[]
                string[] registroResultante = (string[])prod;
                //imprimir los datos
                foreach (string campo in registroResultante)
                {
                    Console.WriteLine("Campo= " + campo);
                }
                Console.WriteLine("registro---------------------------------------------");
            }

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("USERS.....");
            //creamos un CRUD para users
            Admin admin = new Admin("Luis", "Lopez", "Lopez", "6621353535", "luislopez@gmail.com", "calle de los lopez ", "96", "Parque industrial", "Hermorancho", "83297");
            if(admin.create())
                Console.WriteLine("Se insertó correctamente en la tabla");
            else
                Console.WriteLine("ERROR, NO Se insertó correctamente en la tabla. "+CRUD.ERROR);

            Console.WriteLine("-----------------------------------------------------------");

            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------");


            Console.WriteLine("cualquer tecla para finalizar");
            Console.ReadKey();

        }
    }
}
