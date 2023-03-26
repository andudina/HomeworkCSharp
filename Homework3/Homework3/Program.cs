using System.Net.Cache;

namespace Homework3;

public class Program
{

    static void Main(string[] args)
    {

        var cardiologist = new Cardiologist
        {
            Name = "Рейгер Мария Александровна",
            Age = 37,
            Specialization = "Кардиолог",
            Experience = 10,

        };

        var neurologist = new Neurologist
        {
            Name = "Приходько Максим Васильевич",
            Age = 60,
            Specialization = "Невролог",
            Experience = 35,
        };


        var patient1 = new WhoIsPatient
        {
            Name = "Лютик Василиса Максимовна",
            Age = 34,
            Adress = "пр.Ленина, д 12",
            Disease = "Стенокардия",
            State = "Больна",
            Dispanserisation = true,

        };

        var patient2 = new WhoIsPatient
        {
            Name = "Кирилова Милена Семеновна",
            Age = 20,
            Adress = "ул. Весенняя, д 20",
            State = "Больна",
            Disease = "ДЦП",
            Dispanserisation = false,
        };



        patient1.Information();
        patient1.Registration(cardiologist);

        cardiologist.Information();
        cardiologist.Heal(patient1);

        patient2.Information();
        patient2.Registration(neurologist);

        neurologist.Information();
        neurologist.Heal(patient2);


    }
}