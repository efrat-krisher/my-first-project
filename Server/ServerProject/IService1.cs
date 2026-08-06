using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServerProject.BLL;

namespace ServerProject
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool IsPasswordCorrect(string password);
        [OperationContract]
        bool ChangePassword (string newPassword,string oldPassward);
        [OperationContract]
        int AmountCustomers();
        [OperationContract]
        List<BLL.customers> GetCustomers();
        [OperationContract]
        List<BLL.Inviting> GetInvitings();
        [OperationContract]
        bool AddCustomers (BLL.customers c);
        [OperationContract]
        BLL.customers GetCustomerByPhone(string phone);
        [OperationContract]
        List<BLL.Cities> GetCity();
        [OperationContract]
        bool UpdateCustomer(BLL.customers c);
        [OperationContract]
        bool UpdateCity(BLL.Cities C);
        [OperationContract]       
        bool UpdateProduct(BLL.BlProduct p);
        [OperationContract]
        bool UpdateKosher(BLL.kosher kosh);
        [OperationContract]
        bool AddProduct(BLL.BlProduct p);
        [OperationContract]
        List<BLL.BlProduct> GetProducts();
        [OperationContract]
        List<BLL.kosher> GetKosher();
        [OperationContract]
        bool AddKosher(BLL.kosher k);
        [OperationContract]
        List<BLL.kategor> GetKategor();
        //[OperationContract]
        //string GetKategorName();
        [OperationContract]
        List<BLL.Inviting> GetInviting();
        [OperationContract]
        bool AddCity(BLL.Cities c);
        [OperationContract]
        bool deleteproduct(BLL.BlProduct p);
        [OperationContract]
        bool deleteCity(BLL.Cities c);
        [OperationContract]
        bool deleteCustomer(BLL.customers c);
        [OperationContract]
        bool deleteKosher(BLL.kosher kosh);
        [OperationContract]
        bool deleteHazmana(BLL.Inviting I);
            [OperationContract]
        byte[] GetImage(string fileName);
        [OperationContract]
        void SaveImage(byte[] imageArray, string fileName);
        [OperationContract]
        bool CreateOrder(Inviting invite, List<hazmana> LProducts);
        [OperationContract]
         List<BLL.BlProduct> SearchProducts(String P);
        [OperationContract]
      List<BlProduct> GetproductBychoose(kategor w);
        [OperationContract]
        List<hazmana> GetItemsinOrder();
        [OperationContract]
        bool RemoveProductFromInvite(BLL.hazmana p);
        [OperationContract]
        List<BLL.Inviting> GetOrdersByCity(int code);
        //[OperationContract]
        //List<BLL.Inviting> GetOrdersByDay(int code);
        [OperationContract]
         List<BLL.Inviting> GetOrdersByDay();
    }
}
