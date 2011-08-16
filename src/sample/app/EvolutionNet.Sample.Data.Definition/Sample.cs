﻿//------------------------------------------------------------------------------
// <auto-generated>
//	 O código foi gerado por uma ferramenta.
//	 Versão de Tempo de Execução:2.0.50727.5446
//
//	 As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//	 o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EvolutionNet.Sample.Data.Definition {
	using System;
	using System.Collections.Generic;
	using System.Collections;
	using Castle.ActiveRecord;
	using System.ComponentModel;
	using EvolutionNet.MVP.Data.Definition;
	
	
	[ActiveRecord("Categories", Schema="dbo")]
	public partial class Category : SqlServerModel, IModel<int>, INotifyPropertyChanged {
		
		private int iD;
		
		private string categoryName;
		
		private string description;
		
		private byte[] picture;
		
		private IList<Product> products;
		
		public virtual event PropertyChangedEventHandler PropertyChanged;
		
		[PrimaryKey(PrimaryKeyType.Native, "CategoryID", ColumnType="Int32")]
		public virtual int ID {
			get {
				return this.iD;
			}
			set {
				if ((iD != value)) {
					this.iD = value;
					this.NotifyPropertyChanged("ID");
				}
			}
		}
		
		[Property("CategoryName", ColumnType="String", NotNull=true)]
		public virtual string CategoryName {
			get {
				return this.categoryName;
			}
			set {
				if ((categoryName != value)) {
					this.categoryName = value;
					this.NotifyPropertyChanged("CategoryName");
				}
			}
		}
		
		[Property("Description", ColumnType="StringClob")]
		public virtual string Description {
			get {
				return this.description;
			}
			set {
				if ((description != value)) {
					this.description = value;
					this.NotifyPropertyChanged("Description");
				}
			}
		}
		
		[Property("Picture", ColumnType="BinaryBlob")]
		public virtual byte[] Picture {
			get {
				return this.picture;
			}
			set {
				if ((picture != value)) {
					this.picture = value;
					this.NotifyPropertyChanged("Picture");
				}
			}
		}
		
		[HasMany(typeof(Product), ColumnKey="CategoryID", Lazy=true, Table="Products")]
		public virtual IList<Product> Products {
			get {
				return this.products;
			}
			set {
				if ((products != value)) {
					this.products = value;
					this.NotifyPropertyChanged("Products");
				}
			}
		}
		
		protected virtual void NotifyPropertyChanged(string information) {
			if ((PropertyChanged != null)) {
				PropertyChanged(this, new PropertyChangedEventArgs(information));
			}
		}
	}
	
	[ActiveRecord("Territories", Schema="dbo")]
	public partial class Territory : SqlServerModel, IModel<string>, INotifyPropertyChanged {
		
		private string iD;
		
		private string territoryDescription;
		
		private Region region;
		
		private IList<Employee> employees;
		
		public virtual event PropertyChangedEventHandler PropertyChanged;
		
		[PrimaryKey(PrimaryKeyType.Native, "TerritoryID", ColumnType="String")]
		public virtual string ID {
			get {
				return this.iD;
			}
			set {
				if ((iD != value)) {
					this.iD = value;
					this.NotifyPropertyChanged("ID");
				}
			}
		}
		
		[Property("TerritoryDescription", ColumnType="Char", NotNull=true)]
		public virtual string TerritoryDescription {
			get {
				return this.territoryDescription;
			}
			set {
				if ((territoryDescription != value)) {
					this.territoryDescription = value;
					this.NotifyPropertyChanged("TerritoryDescription");
				}
			}
		}
		
		[BelongsTo("RegionID")]
		public virtual Region Region {
			get {
				return this.region;
			}
			set {
				if ((region != value)) {
					this.region = value;
					this.NotifyPropertyChanged("Region");
				}
			}
		}
		
		[HasAndBelongsToMany(typeof(Employee), ColumnRef="EmployeeID", ColumnKey="TerritoryID", Lazy=true, Schema="dbo", Table="EmployeeTerritories")]
		public virtual IList<Employee> Employees {
			get {
				return this.employees;
			}
			set {
				if ((employees != value)) {
					this.employees = value;
					this.NotifyPropertyChanged("Employees");
				}
			}
		}
		
		protected virtual void NotifyPropertyChanged(string information) {
			if ((PropertyChanged != null)) {
				PropertyChanged(this, new PropertyChangedEventArgs(information));
			}
		}
	}
	
	[ActiveRecord("CustomerDemographics", Schema="dbo")]
	public partial class CustomerDemographics : SqlServerModel, IModel<string>, INotifyPropertyChanged {
		
		private string iD;
		
		private string customerDesc;
		
		private IList<Customer> customers;
		
		public virtual event PropertyChangedEventHandler PropertyChanged;
		
		[PrimaryKey(PrimaryKeyType.Native, "CustomerTypeID", ColumnType="Char")]
		public virtual string ID {
			get {
				return this.iD;
			}
			set {
				if ((iD != value)) {
					this.iD = value;
					this.NotifyPropertyChanged("ID");
				}
			}
		}
		
		[Property("CustomerDesc", ColumnType="StringClob")]
		public virtual string CustomerDesc {
			get {
				return this.customerDesc;
			}
			set {
				if ((customerDesc != value)) {
					this.customerDesc = value;
					this.NotifyPropertyChanged("CustomerDesc");
				}
			}
		}
		
		[HasAndBelongsToMany(typeof(Customer), ColumnRef="CustomerID", ColumnKey="CustomerTypeID", Lazy=true, Schema="dbo", Table="CustomerCustomerDemo")]
		public virtual IList<Customer> Customers {
			get {
				return this.customers;
			}
			set {
				if ((customers != value)) {
					this.customers = value;
					this.NotifyPropertyChanged("Customers");
				}
			}
		}
		
		protected virtual void NotifyPropertyChanged(string information) {
			if ((PropertyChanged != null)) {
				PropertyChanged(this, new PropertyChangedEventArgs(information));
			}
		}
	}
	
	[ActiveRecord("Customers", Schema="dbo")]
	public partial class Customer : SqlServerModel, IModel<string>, INotifyPropertyChanged {
		
		private string iD;
		
		private string companyName;
		
		private string contactName;
		
		private string contactTitle;
		
		private string address;
		
		private string city;
		
		private string region;
		
		private string postalCode;
		
		private string country;
		
		private string phone;
		
		private string fax;
		
		private IList<Order> orders;
		
		private IList<CustomerDemographics> customerDemographics;
		
		public virtual event PropertyChangedEventHandler PropertyChanged;
		
		[PrimaryKey(PrimaryKeyType.Native, "CustomerID", ColumnType="Char")]
		public virtual string ID {
			get {
				return this.iD;
			}
			set {
				if ((iD != value)) {
					this.iD = value;
					this.NotifyPropertyChanged("ID");
				}
			}
		}
		
		[Property("CompanyName", ColumnType="String", NotNull=true)]
		public virtual string CompanyName {
			get {
				return this.companyName;
			}
			set {
				if ((companyName != value)) {
					this.companyName = value;
					this.NotifyPropertyChanged("CompanyName");
				}
			}
		}
		
		[Property("ContactName", ColumnType="String")]
		public virtual string ContactName {
			get {
				return this.contactName;
			}
			set {
				if ((contactName != value)) {
					this.contactName = value;
					this.NotifyPropertyChanged("ContactName");
				}
			}
		}
		
		[Property("ContactTitle", ColumnType="String")]
		public virtual string ContactTitle {
			get {
				return this.contactTitle;
			}
			set {
				if ((contactTitle != value)) {
					this.contactTitle = value;
					this.NotifyPropertyChanged("ContactTitle");
				}
			}
		}
		
		[Property("Address", ColumnType="String")]
		public virtual string Address {
			get {
				return this.address;
			}
			set {
				if ((address != value)) {
					this.address = value;
					this.NotifyPropertyChanged("Address");
				}
			}
		}
		
		[Property("City", ColumnType="String")]
		public virtual string City {
			get {
				return this.city;
			}
			set {
				if ((city != value)) {
					this.city = value;
					this.NotifyPropertyChanged("City");
				}
			}
		}
		
		[Property("Region", ColumnType="String")]
		public virtual string Region {
			get {
				return this.region;
			}
			set {
				if ((region != value)) {
					this.region = value;
					this.NotifyPropertyChanged("Region");
				}
			}
		}
		
		[Property("PostalCode", ColumnType="String")]
		public virtual string PostalCode {
			get {
				return this.postalCode;
			}
			set {
				if ((postalCode != value)) {
					this.postalCode = value;
					this.NotifyPropertyChanged("PostalCode");
				}
			}
		}
		
		[Property("Country", ColumnType="String")]
		public virtual string Country {
			get {
				return this.country;
			}
			set {
				if ((country != value)) {
					this.country = value;
					this.NotifyPropertyChanged("Country");
				}
			}
		}
		
		[Property("Phone", ColumnType="String")]
		public virtual string Phone {
			get {
				return this.phone;
			}
			set {
				if ((phone != value)) {
					this.phone = value;
					this.NotifyPropertyChanged("Phone");
				}
			}
		}
		
		[Property("Fax", ColumnType="String")]
		public virtual string Fax {
			get {
				return this.fax;
			}
			set {
				if ((fax != value)) {
					this.fax = value;
					this.NotifyPropertyChanged("Fax");
				}
			}
		}
		
		[HasMany(typeof(Order), ColumnKey="CustomerID", Lazy=true, Table="Orders")]
		public virtual IList<Order> Orders {
			get {
				return this.orders;
			}
			set {
				if ((orders != value)) {
					this.orders = value;
					this.NotifyPropertyChanged("Orders");
				}
			}
		}
		
		[HasAndBelongsToMany(typeof(CustomerDemographics), ColumnRef="CustomerTypeID", ColumnKey="CustomerID", Lazy=true, Schema="dbo", Table="CustomerCustomerDemo")]
		public virtual IList<CustomerDemographics> CustomerDemographics {
			get {
				return this.customerDemographics;
			}
			set {
				if ((customerDemographics != value)) {
					this.customerDemographics = value;
					this.NotifyPropertyChanged("CustomerDemographics");
				}
			}
		}
		
		protected virtual void NotifyPropertyChanged(string information) {
			if ((PropertyChanged != null)) {
				PropertyChanged(this, new PropertyChangedEventArgs(information));
			}
		}
	}
	
	[ActiveRecord("Employees", Schema="dbo")]
	public partial class Employee : SqlServerModel, IModel<int>, INotifyPropertyChanged {
		
		private int iD;
		
		private string lastName;
		
		private string firstName;
		
		private string title;
		
		private string titleOfCourtesy;
		
		private System.DateTime birthDate;
		
		private System.DateTime hireDate;
		
		private string address;
		
		private string city;
		
		private string region;
		
		private string postalCode;
		
		private string country;
		
		private string homePhone;
		
		private string extension;
		
		private byte[] photo;
		
		private string notes;
		
		private string photoPath;
		
		private IList<Employee> employees;
		
		private IList<Order> orders;
		
		private Employee reportsTo;
		
		private IList<Territory> territories;
		
		public virtual event PropertyChangedEventHandler PropertyChanged;
		
		[PrimaryKey(PrimaryKeyType.Native, "EmployeeID", ColumnType="Int32")]
		public virtual int ID {
			get {
				return this.iD;
			}
			set {
				if ((iD != value)) {
					this.iD = value;
					this.NotifyPropertyChanged("ID");
				}
			}
		}
		
		[Property("LastName", ColumnType="String", NotNull=true)]
		public virtual string LastName {
			get {
				return this.lastName;
			}
			set {
				if ((lastName != value)) {
					this.lastName = value;
					this.NotifyPropertyChanged("LastName");
				}
			}
		}
		
		[Property("FirstName", ColumnType="String", NotNull=true)]
		public virtual string FirstName {
			get {
				return this.firstName;
			}
			set {
				if ((firstName != value)) {
					this.firstName = value;
					this.NotifyPropertyChanged("FirstName");
				}
			}
		}
		
		[Property("Title", ColumnType="String")]
		public virtual string Title {
			get {
				return this.title;
			}
			set {
				if ((title != value)) {
					this.title = value;
					this.NotifyPropertyChanged("Title");
				}
			}
		}
		
		[Property("TitleOfCourtesy", ColumnType="String")]
		public virtual string TitleOfCourtesy {
			get {
				return this.titleOfCourtesy;
			}
			set {
				if ((titleOfCourtesy != value)) {
					this.titleOfCourtesy = value;
					this.NotifyPropertyChanged("TitleOfCourtesy");
				}
			}
		}
		
		[Property("BirthDate", ColumnType="Timestamp")]
		public virtual System.DateTime BirthDate {
			get {
				return this.birthDate;
			}
			set {
				if ((birthDate != value)) {
					this.birthDate = value;
					this.NotifyPropertyChanged("BirthDate");
				}
			}
		}
		
		[Property("HireDate", ColumnType="Timestamp")]
		public virtual System.DateTime HireDate {
			get {
				return this.hireDate;
			}
			set {
				if ((hireDate != value)) {
					this.hireDate = value;
					this.NotifyPropertyChanged("HireDate");
				}
			}
		}
		
		[Property("Address", ColumnType="String")]
		public virtual string Address {
			get {
				return this.address;
			}
			set {
				if ((address != value)) {
					this.address = value;
					this.NotifyPropertyChanged("Address");
				}
			}
		}
		
		[Property("City", ColumnType="String")]
		public virtual string City {
			get {
				return this.city;
			}
			set {
				if ((city != value)) {
					this.city = value;
					this.NotifyPropertyChanged("City");
				}
			}
		}
		
		[Property("Region", ColumnType="String")]
		public virtual string Region {
			get {
				return this.region;
			}
			set {
				if ((region != value)) {
					this.region = value;
					this.NotifyPropertyChanged("Region");
				}
			}
		}
		
		[Property("PostalCode", ColumnType="String")]
		public virtual string PostalCode {
			get {
				return this.postalCode;
			}
			set {
				if ((postalCode != value)) {
					this.postalCode = value;
					this.NotifyPropertyChanged("PostalCode");
				}
			}
		}
		
		[Property("Country", ColumnType="String")]
		public virtual string Country {
			get {
				return this.country;
			}
			set {
				if ((country != value)) {
					this.country = value;
					this.NotifyPropertyChanged("Country");
				}
			}
		}
		
		[Property("HomePhone", ColumnType="String")]
		public virtual string HomePhone {
			get {
				return this.homePhone;
			}
			set {
				if ((homePhone != value)) {
					this.homePhone = value;
					this.NotifyPropertyChanged("HomePhone");
				}
			}
		}
		
		[Property("Extension", ColumnType="String")]
		public virtual string Extension {
			get {
				return this.extension;
			}
			set {
				if ((extension != value)) {
					this.extension = value;
					this.NotifyPropertyChanged("Extension");
				}
			}
		}
		
		[Property("Photo", ColumnType="BinaryBlob")]
		public virtual byte[] Photo {
			get {
				return this.photo;
			}
			set {
				if ((photo != value)) {
					this.photo = value;
					this.NotifyPropertyChanged("Photo");
				}
			}
		}
		
		[Property("Notes", ColumnType="StringClob")]
		public virtual string Notes {
			get {
				return this.notes;
			}
			set {
				if ((notes != value)) {
					this.notes = value;
					this.NotifyPropertyChanged("Notes");
				}
			}
		}
		
		[Property("PhotoPath", ColumnType="String")]
		public virtual string PhotoPath {
			get {
				return this.photoPath;
			}
			set {
				if ((photoPath != value)) {
					this.photoPath = value;
					this.NotifyPropertyChanged("PhotoPath");
				}
			}
		}
		
		[HasMany(typeof(Employee), ColumnKey="ReportsTo", Lazy=true, Table="Employees")]
		public virtual IList<Employee> Employees {
			get {
				return this.employees;
			}
			set {
				if ((employees != value)) {
					this.employees = value;
					this.NotifyPropertyChanged("Employees");
				}
			}
		}
		
		[HasMany(typeof(Order), ColumnKey="EmployeeID", Lazy=true, Table="Orders")]
		public virtual IList<Order> Orders {
			get {
				return this.orders;
			}
			set {
				if ((orders != value)) {
					this.orders = value;
					this.NotifyPropertyChanged("Orders");
				}
			}
		}
		
		[BelongsTo()]
		public virtual Employee ReportsTo {
			get {
				return this.reportsTo;
			}
			set {
				if ((reportsTo != value)) {
					this.reportsTo = value;
					this.NotifyPropertyChanged("ReportsTo");
				}
			}
		}
		
		[HasAndBelongsToMany(typeof(Territory), ColumnRef="TerritoryID", ColumnKey="EmployeeID", Lazy=true, Schema="dbo", Table="EmployeeTerritories")]
		public virtual IList<Territory> Territories {
			get {
				return this.territories;
			}
			set {
				if ((territories != value)) {
					this.territories = value;
					this.NotifyPropertyChanged("Territories");
				}
			}
		}
		
		protected virtual void NotifyPropertyChanged(string information) {
			if ((PropertyChanged != null)) {
				PropertyChanged(this, new PropertyChangedEventArgs(information));
			}
		}
	}
	
	[ActiveRecord("Order Details", Schema="dbo")]
	public partial class OrderDetail : SqlServerModel, IModel<OrderDetailKey>, INotifyPropertyChanged {
		
		private string unitPrice;
		
		private short quantity;
		
		private float discount;
		
		private OrderDetailKey orderDetailKey;
		
		private Order order;
		
		private Product product;
		
		public virtual event PropertyChangedEventHandler PropertyChanged;
		
		[Property("UnitPrice", ColumnType="String", NotNull=true)]
		public virtual string UnitPrice {
			get {
				return this.unitPrice;
			}
			set {
				if ((unitPrice != value)) {
					this.unitPrice = value;
					this.NotifyPropertyChanged("UnitPrice");
				}
			}
		}
		
		[Property("Quantity", ColumnType="Int16", NotNull=true)]
		public virtual short Quantity {
			get {
				return this.quantity;
			}
			set {
				if ((quantity != value)) {
					this.quantity = value;
					this.NotifyPropertyChanged("Quantity");
				}
			}
		}
		
		[Property("Discount", ColumnType="Single", NotNull=true)]
		public virtual float Discount {
			get {
				return this.discount;
			}
			set {
				if ((discount != value)) {
					this.discount = value;
					this.NotifyPropertyChanged("Discount");
				}
			}
		}
		
		[CompositeKey()]
		public virtual OrderDetailKey OrderDetailKey {
			get {
				return this.orderDetailKey;
			}
			set {
				if ((orderDetailKey != value)) {
					this.orderDetailKey = value;
					this.NotifyPropertyChanged("OrderDetailKey");
				}
			}
		}
		
		[BelongsTo("OrderID")]
		public virtual Order Order {
			get {
				return this.order;
			}
			set {
				if ((order != value)) {
					this.order = value;
					this.NotifyPropertyChanged("Order");
				}
			}
		}
		
		[BelongsTo("ProductID")]
		public virtual Product Product {
			get {
				return this.product;
			}
			set {
				if ((product != value)) {
					this.product = value;
					this.NotifyPropertyChanged("Product");
				}
			}
		}
		
		protected virtual void NotifyPropertyChanged(string information) {
			if ((PropertyChanged != null)) {
				PropertyChanged(this, new PropertyChangedEventArgs(information));
			}
		}
	}
	
	[Serializable()]
	public partial class OrderDetailKey : INotifyPropertyChanged {
		
		private int order;
		
		private int product;
		
		public virtual event PropertyChangedEventHandler PropertyChanged;
		
		[KeyProperty(Column="OrderID", ColumnType="Int32")]
		public virtual int Order {
			get {
				return this.order;
			}
			set {
				if ((order != value)) {
					this.order = value;
					this.NotifyPropertyChanged("Order");
				}
			}
		}
		
		[KeyProperty(Column="ProductID", ColumnType="Int32")]
		public virtual int Product {
			get {
				return this.product;
			}
			set {
				if ((product != value)) {
					this.product = value;
					this.NotifyPropertyChanged("Product");
				}
			}
		}
		
		protected virtual void NotifyPropertyChanged(string information) {
			if ((PropertyChanged != null)) {
				PropertyChanged(this, new PropertyChangedEventArgs(information));
			}
		}
		
		public override string ToString() {
			return String.Join(":", new string[] {
						this.order.ToString(),
						this.product.ToString()});
		}
		
		public override bool Equals(object obj) {
			if ((obj == this)) {
				return true;
			}
			if (((obj == null) 
						|| (obj.GetType() != this.GetType()))) {
				return false;
			}
			OrderDetailKey test = ((OrderDetailKey)(obj));
			return (((order == test.order) 
						|| ((order != null) 
						&& order.Equals(test.order))) 
						&& ((product == test.product) 
						|| ((product != null) 
						&& product.Equals(test.product))));
		}
		
		public override int GetHashCode() {
			return XorHelper(order.GetHashCode(), product.GetHashCode());
		}
		
		private int XorHelper(int left, int right) {
			return left ^ right;
		}
	}
	
	[ActiveRecord("Orders", Schema="dbo")]
	public partial class Order : SqlServerModel, IModel<int>, INotifyPropertyChanged {
		
		private int iD;
		
		private System.DateTime orderDate;
		
		private System.DateTime requiredDate;
		
		private System.DateTime shippedDate;
		
		private string freight;
		
		private string shipName;
		
		private string shipAddress;
		
		private string shipCity;
		
		private string shipRegion;
		
		private string shipPostalCode;
		
		private string shipCountry;
		
		private IList<OrderDetail> orderDetails;
		
		private Customer customer;
		
		private Employee employee;
		
		private Shipper shipper;
		
		public virtual event PropertyChangedEventHandler PropertyChanged;
		
		[PrimaryKey(PrimaryKeyType.Native, "OrderID", ColumnType="Int32")]
		public virtual int ID {
			get {
				return this.iD;
			}
			set {
				if ((iD != value)) {
					this.iD = value;
					this.NotifyPropertyChanged("ID");
				}
			}
		}
		
		[Property("OrderDate", ColumnType="Timestamp")]
		public virtual System.DateTime OrderDate {
			get {
				return this.orderDate;
			}
			set {
				if ((orderDate != value)) {
					this.orderDate = value;
					this.NotifyPropertyChanged("OrderDate");
				}
			}
		}
		
		[Property("RequiredDate", ColumnType="Timestamp")]
		public virtual System.DateTime RequiredDate {
			get {
				return this.requiredDate;
			}
			set {
				if ((requiredDate != value)) {
					this.requiredDate = value;
					this.NotifyPropertyChanged("RequiredDate");
				}
			}
		}
		
		[Property("ShippedDate", ColumnType="Timestamp")]
		public virtual System.DateTime ShippedDate {
			get {
				return this.shippedDate;
			}
			set {
				if ((shippedDate != value)) {
					this.shippedDate = value;
					this.NotifyPropertyChanged("ShippedDate");
				}
			}
		}
		
		[Property("Freight", ColumnType="String")]
		public virtual string Freight {
			get {
				return this.freight;
			}
			set {
				if ((freight != value)) {
					this.freight = value;
					this.NotifyPropertyChanged("Freight");
				}
			}
		}
		
		[Property("ShipName", ColumnType="String")]
		public virtual string ShipName {
			get {
				return this.shipName;
			}
			set {
				if ((shipName != value)) {
					this.shipName = value;
					this.NotifyPropertyChanged("ShipName");
				}
			}
		}
		
		[Property("ShipAddress", ColumnType="String")]
		public virtual string ShipAddress {
			get {
				return this.shipAddress;
			}
			set {
				if ((shipAddress != value)) {
					this.shipAddress = value;
					this.NotifyPropertyChanged("ShipAddress");
				}
			}
		}
		
		[Property("ShipCity", ColumnType="String")]
		public virtual string ShipCity {
			get {
				return this.shipCity;
			}
			set {
				if ((shipCity != value)) {
					this.shipCity = value;
					this.NotifyPropertyChanged("ShipCity");
				}
			}
		}
		
		[Property("ShipRegion", ColumnType="String")]
		public virtual string ShipRegion {
			get {
				return this.shipRegion;
			}
			set {
				if ((shipRegion != value)) {
					this.shipRegion = value;
					this.NotifyPropertyChanged("ShipRegion");
				}
			}
		}
		
		[Property("ShipPostalCode", ColumnType="String")]
		public virtual string ShipPostalCode {
			get {
				return this.shipPostalCode;
			}
			set {
				if ((shipPostalCode != value)) {
					this.shipPostalCode = value;
					this.NotifyPropertyChanged("ShipPostalCode");
				}
			}
		}
		
		[Property("ShipCountry", ColumnType="String")]
		public virtual string ShipCountry {
			get {
				return this.shipCountry;
			}
			set {
				if ((shipCountry != value)) {
					this.shipCountry = value;
					this.NotifyPropertyChanged("ShipCountry");
				}
			}
		}
		
		[HasMany(typeof(OrderDetail), ColumnKey="OrderID", Lazy=true, Table="Order Details")]
		public virtual IList<OrderDetail> OrderDetails {
			get {
				return this.orderDetails;
			}
			set {
				if ((orderDetails != value)) {
					this.orderDetails = value;
					this.NotifyPropertyChanged("OrderDetails");
				}
			}
		}
		
		[BelongsTo("CustomerID")]
		public virtual Customer Customer {
			get {
				return this.customer;
			}
			set {
				if ((customer != value)) {
					this.customer = value;
					this.NotifyPropertyChanged("Customer");
				}
			}
		}
		
		[BelongsTo("EmployeeID")]
		public virtual Employee Employee {
			get {
				return this.employee;
			}
			set {
				if ((employee != value)) {
					this.employee = value;
					this.NotifyPropertyChanged("Employee");
				}
			}
		}
		
		[BelongsTo("ShipVia")]
		public virtual Shipper Shipper {
			get {
				return this.shipper;
			}
			set {
				if ((shipper != value)) {
					this.shipper = value;
					this.NotifyPropertyChanged("Shipper");
				}
			}
		}
		
		protected virtual void NotifyPropertyChanged(string information) {
			if ((PropertyChanged != null)) {
				PropertyChanged(this, new PropertyChangedEventArgs(information));
			}
		}
	}
	
	[ActiveRecord("Products", Schema="dbo")]
	public partial class Product : SqlServerModel, IModel<int>, INotifyPropertyChanged {
		
		private int iD;
		
		private string productName;
		
		private string quantityPerUnit;
		
		private string unitPrice;
		
		private short unitsInStock;
		
		private short unitsOnOrder;
		
		private short reorderLevel;
		
		private bool discontinued;
		
		private IList<OrderDetail> orderDetails;
		
		private Category category;
		
		private Supplier supplier;
		
		public virtual event PropertyChangedEventHandler PropertyChanged;
		
		[PrimaryKey(PrimaryKeyType.Native, "ProductID", ColumnType="Int32")]
		public virtual int ID {
			get {
				return this.iD;
			}
			set {
				if ((iD != value)) {
					this.iD = value;
					this.NotifyPropertyChanged("ID");
				}
			}
		}
		
		[Property("ProductName", ColumnType="String", NotNull=true)]
		public virtual string ProductName {
			get {
				return this.productName;
			}
			set {
				if ((productName != value)) {
					this.productName = value;
					this.NotifyPropertyChanged("ProductName");
				}
			}
		}
		
		[Property("QuantityPerUnit", ColumnType="String")]
		public virtual string QuantityPerUnit {
			get {
				return this.quantityPerUnit;
			}
			set {
				if ((quantityPerUnit != value)) {
					this.quantityPerUnit = value;
					this.NotifyPropertyChanged("QuantityPerUnit");
				}
			}
		}
		
		[Property("UnitPrice", ColumnType="String")]
		public virtual string UnitPrice {
			get {
				return this.unitPrice;
			}
			set {
				if ((unitPrice != value)) {
					this.unitPrice = value;
					this.NotifyPropertyChanged("UnitPrice");
				}
			}
		}
		
		[Property("UnitsInStock", ColumnType="Int16")]
		public virtual short UnitsInStock {
			get {
				return this.unitsInStock;
			}
			set {
				if ((unitsInStock != value)) {
					this.unitsInStock = value;
					this.NotifyPropertyChanged("UnitsInStock");
				}
			}
		}
		
		[Property("UnitsOnOrder", ColumnType="Int16")]
		public virtual short UnitsOnOrder {
			get {
				return this.unitsOnOrder;
			}
			set {
				if ((unitsOnOrder != value)) {
					this.unitsOnOrder = value;
					this.NotifyPropertyChanged("UnitsOnOrder");
				}
			}
		}
		
		[Property("ReorderLevel", ColumnType="Int16")]
		public virtual short ReorderLevel {
			get {
				return this.reorderLevel;
			}
			set {
				if ((reorderLevel != value)) {
					this.reorderLevel = value;
					this.NotifyPropertyChanged("ReorderLevel");
				}
			}
		}
		
		[Property("Discontinued", ColumnType="Boolean", NotNull=true)]
		public virtual bool Discontinued {
			get {
				return this.discontinued;
			}
			set {
				if ((discontinued != value)) {
					this.discontinued = value;
					this.NotifyPropertyChanged("Discontinued");
				}
			}
		}
		
		[HasMany(typeof(OrderDetail), ColumnKey="ProductID", Lazy=true, Table="Order Details")]
		public virtual IList<OrderDetail> OrderDetails {
			get {
				return this.orderDetails;
			}
			set {
				if ((orderDetails != value)) {
					this.orderDetails = value;
					this.NotifyPropertyChanged("OrderDetails");
				}
			}
		}
		
		[BelongsTo("CategoryID")]
		public virtual Category Category {
			get {
				return this.category;
			}
			set {
				if ((category != value)) {
					this.category = value;
					this.NotifyPropertyChanged("Category");
				}
			}
		}
		
		[BelongsTo("SupplierID")]
		public virtual Supplier Supplier {
			get {
				return this.supplier;
			}
			set {
				if ((supplier != value)) {
					this.supplier = value;
					this.NotifyPropertyChanged("Supplier");
				}
			}
		}
		
		protected virtual void NotifyPropertyChanged(string information) {
			if ((PropertyChanged != null)) {
				PropertyChanged(this, new PropertyChangedEventArgs(information));
			}
		}
	}
	
	[ActiveRecord("Region", Schema="dbo")]
	public partial class Region : SqlServerModel, IModel<int>, INotifyPropertyChanged {
		
		private int iD;
		
		private string regionDescription;
		
		private IList<Territory> territories;
		
		public virtual event PropertyChangedEventHandler PropertyChanged;
		
		[PrimaryKey(PrimaryKeyType.Native, "RegionID", ColumnType="Int32")]
		public virtual int ID {
			get {
				return this.iD;
			}
			set {
				if ((iD != value)) {
					this.iD = value;
					this.NotifyPropertyChanged("ID");
				}
			}
		}
		
		[Property("RegionDescription", ColumnType="Char", NotNull=true)]
		public virtual string RegionDescription {
			get {
				return this.regionDescription;
			}
			set {
				if ((regionDescription != value)) {
					this.regionDescription = value;
					this.NotifyPropertyChanged("RegionDescription");
				}
			}
		}
		
		[HasMany(typeof(Territory), ColumnKey="RegionID", Lazy=true, Table="Territories")]
		public virtual IList<Territory> Territories {
			get {
				return this.territories;
			}
			set {
				if ((territories != value)) {
					this.territories = value;
					this.NotifyPropertyChanged("Territories");
				}
			}
		}
		
		protected virtual void NotifyPropertyChanged(string information) {
			if ((PropertyChanged != null)) {
				PropertyChanged(this, new PropertyChangedEventArgs(information));
			}
		}
	}
	
	[ActiveRecord("Shippers", Schema="dbo")]
	public partial class Shipper : SqlServerModel, IModel<int>, INotifyPropertyChanged {
		
		private int iD;
		
		private string companyName;
		
		private string phone;
		
		private IList<Order> orders;
		
		public virtual event PropertyChangedEventHandler PropertyChanged;
		
		[PrimaryKey(PrimaryKeyType.Native, "ShipperID", ColumnType="Int32")]
		public virtual int ID {
			get {
				return this.iD;
			}
			set {
				if ((iD != value)) {
					this.iD = value;
					this.NotifyPropertyChanged("ID");
				}
			}
		}
		
		[Property("CompanyName", ColumnType="String", NotNull=true)]
		public virtual string CompanyName {
			get {
				return this.companyName;
			}
			set {
				if ((companyName != value)) {
					this.companyName = value;
					this.NotifyPropertyChanged("CompanyName");
				}
			}
		}
		
		[Property("Phone", ColumnType="String")]
		public virtual string Phone {
			get {
				return this.phone;
			}
			set {
				if ((phone != value)) {
					this.phone = value;
					this.NotifyPropertyChanged("Phone");
				}
			}
		}
		
		[HasMany(typeof(Order), ColumnKey="ShipVia", Lazy=true, Table="Orders")]
		public virtual IList<Order> Orders {
			get {
				return this.orders;
			}
			set {
				if ((orders != value)) {
					this.orders = value;
					this.NotifyPropertyChanged("Orders");
				}
			}
		}
		
		protected virtual void NotifyPropertyChanged(string information) {
			if ((PropertyChanged != null)) {
				PropertyChanged(this, new PropertyChangedEventArgs(information));
			}
		}
	}
	
	[ActiveRecord("Suppliers", Schema="dbo")]
	public partial class Supplier : SqlServerModel, IModel<int>, INotifyPropertyChanged {
		
		private int iD;
		
		private string companyName;
		
		private string contactName;
		
		private string contactTitle;
		
		private string address;
		
		private string city;
		
		private string region;
		
		private string postalCode;
		
		private string country;
		
		private string phone;
		
		private string fax;
		
		private string homePage;
		
		private IList<Product> products;
		
		public virtual event PropertyChangedEventHandler PropertyChanged;
		
		[PrimaryKey(PrimaryKeyType.Native, "SupplierID", ColumnType="Int32")]
		public virtual int ID {
			get {
				return this.iD;
			}
			set {
				if ((iD != value)) {
					this.iD = value;
					this.NotifyPropertyChanged("ID");
				}
			}
		}
		
		[Property("CompanyName", ColumnType="String", NotNull=true)]
		public virtual string CompanyName {
			get {
				return this.companyName;
			}
			set {
				if ((companyName != value)) {
					this.companyName = value;
					this.NotifyPropertyChanged("CompanyName");
				}
			}
		}
		
		[Property("ContactName", ColumnType="String")]
		public virtual string ContactName {
			get {
				return this.contactName;
			}
			set {
				if ((contactName != value)) {
					this.contactName = value;
					this.NotifyPropertyChanged("ContactName");
				}
			}
		}
		
		[Property("ContactTitle", ColumnType="String")]
		public virtual string ContactTitle {
			get {
				return this.contactTitle;
			}
			set {
				if ((contactTitle != value)) {
					this.contactTitle = value;
					this.NotifyPropertyChanged("ContactTitle");
				}
			}
		}
		
		[Property("Address", ColumnType="String")]
		public virtual string Address {
			get {
				return this.address;
			}
			set {
				if ((address != value)) {
					this.address = value;
					this.NotifyPropertyChanged("Address");
				}
			}
		}
		
		[Property("City", ColumnType="String")]
		public virtual string City {
			get {
				return this.city;
			}
			set {
				if ((city != value)) {
					this.city = value;
					this.NotifyPropertyChanged("City");
				}
			}
		}
		
		[Property("Region", ColumnType="String")]
		public virtual string Region {
			get {
				return this.region;
			}
			set {
				if ((region != value)) {
					this.region = value;
					this.NotifyPropertyChanged("Region");
				}
			}
		}
		
		[Property("PostalCode", ColumnType="String")]
		public virtual string PostalCode {
			get {
				return this.postalCode;
			}
			set {
				if ((postalCode != value)) {
					this.postalCode = value;
					this.NotifyPropertyChanged("PostalCode");
				}
			}
		}
		
		[Property("Country", ColumnType="String")]
		public virtual string Country {
			get {
				return this.country;
			}
			set {
				if ((country != value)) {
					this.country = value;
					this.NotifyPropertyChanged("Country");
				}
			}
		}
		
		[Property("Phone", ColumnType="String")]
		public virtual string Phone {
			get {
				return this.phone;
			}
			set {
				if ((phone != value)) {
					this.phone = value;
					this.NotifyPropertyChanged("Phone");
				}
			}
		}
		
		[Property("Fax", ColumnType="String")]
		public virtual string Fax {
			get {
				return this.fax;
			}
			set {
				if ((fax != value)) {
					this.fax = value;
					this.NotifyPropertyChanged("Fax");
				}
			}
		}
		
		[Property("HomePage", ColumnType="StringClob")]
		public virtual string HomePage {
			get {
				return this.homePage;
			}
			set {
				if ((homePage != value)) {
					this.homePage = value;
					this.NotifyPropertyChanged("HomePage");
				}
			}
		}
		
		[HasMany(typeof(Product), ColumnKey="SupplierID", Lazy=true, Table="Products")]
		public virtual IList<Product> Products {
			get {
				return this.products;
			}
			set {
				if ((products != value)) {
					this.products = value;
					this.NotifyPropertyChanged("Products");
				}
			}
		}
		
		protected virtual void NotifyPropertyChanged(string information) {
			if ((PropertyChanged != null)) {
				PropertyChanged(this, new PropertyChangedEventArgs(information));
			}
		}
	}
	
	public class SampleHelper {
		
		public static Type[] GetTypes() {
			return new Type[] {
					typeof(Category),
					typeof(Territory),
					typeof(CustomerDemographics),
					typeof(Customer),
					typeof(Employee),
					typeof(OrderDetail),
					typeof(Order),
					typeof(Product),
					typeof(Region),
					typeof(Shipper),
					typeof(Supplier)};
		}
	}
}
