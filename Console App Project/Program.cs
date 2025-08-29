using Console_App_Project.Utilities;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Console_App_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManagmentApplication Run = new ManagmentApplication();
            Run.Run();







        }
    }
}

//Product class:

//Id,
//Name,
//Price,
//Stock

//PrintInfo()

//Her yarandiqda Id dinamik olaraq teyin olunmali ve unikal olmalidir.
//Mehsulun adi Unikal olmali ve en azi 1 xarakterden ibaret olmalidir

//------------------

//OrderItem class: (bu class sifarish edilen her mehsulu yekun sifarishde temsil edir)

//Id,
//Product Product
//Count  - bu mehsuldan ne qeder sifarish olunub
//Price  - mehsulun qiymeti
//SubTotal - bu mehsulun say-a gore umumi tutari

//------------------

//Order class: (Butov bir sifarishi temsil edir)

//Id
//List<OrderItem> Items
//Total
//Email  - sifarish eden shexsin emaili
//OrderStatus Status
//DateTime OrderedAt

//PrintInfo()
//-------------

//enum OrderStatus :

//Pending
//Confirmed
//Completed

//--------------------------


//Application ishe dushdukde ashagidaki menu cixmalidir:

//1.Create Product
//2.Delete Product
//3.Get Product By Id
//3.Show All Product
//4.Refill Product
//5.Order Product
//6.Shaw All Orders
//7.Change Order Status


//1)Create Product - ishe dushdukde Name Price ve Stock gonderilmelidir. Gonderilen deyerler yoxlandiqdan sonra Product yaranib File-daxiline yazilmalidir. Vacib yoxlamalar bu add bashqa mehsulun olmamasi ve Price ile Stock menfi ola bilmez(Price 0-da ola bilmir)

//2)Delete Product - ishe dushdukde Id gonderilmeli hemin Id-li mehsul silinmelidir(File-dan)

//3)Get Product By Id - Id goturulur hemin Id-li mehsul tapilib melumatlari ekrana cixarir

//3)Show All Product - Butun mehsullari ekrana cap etmelidir. Stocku bitmish mehsullarin qarshisinda "Out of Stock" yazilmalidir

//4)Refill Product - Id qebul olunur hemin Id-li mehsul tapildiqda uzerine gelecek Stock deyeri qebul olunur(menfi ola bilmez) ve hemin mehsulun Stock-u o qeder artirilir. Mehsul tapilmadiqda "Product not found" yazilib esas sehifeye qayidilir

//5)Order Product -ilk olaraq sifarish sahibinin Emailini gotururuk(email-de mutleq '@' xarakteri olmalidir) sonra Id qebul olunur hemin Id-li mehsul movcuddursa istifadeciden bu mehsuldan nece eded almaq istediyi goturulur eger bu mehsuldan istenilen sayda movcud deyilse sifarish heyata kecmir. Eger kifayet qeder varsa hemin mehsulu temsil eden OrderItem yaranir ve sifarishe devam etmek teklifi gonderilir. Eger istifadeci bashqa mehsuluda satisha elave elemek isteyirse bu zaman Diger mehsulun Id in gonderir ve prosses tekrarlanir. Nehayet mohsul secimleri bitdikde Order yaranir OrderItem-lari list olaraq ozunde saxlayir ve Total hesablanaraq Orders.json file-na yazilir. Order yaranan zaman default olaraq OrderStatus-a Pending deyeri verilir

//6)Shaw All Orders - ishe dushdukde butun sifarishlerin melumatlarini ekrana cixarir(OrderStatus-da mutleq gorsenmelidir)

//7)Change Order Status - Id qebul edirik hemin Id-li Orderi axtaririq. Bele bir Order movcuddursa istifadeciye Status secimlerini siraliyiriq secdiyi Statusu hemin Order-in OrderStatus-a menimsedirik