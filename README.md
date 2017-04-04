A.React.js: Introduction and Hello World with ASP.NET MVC 5
https://www.nuget.org/packages/React.Web.Mvc4

http://techbrij.com/react-js-asp-net-mvc-introduction
	1. Open Visual Studio > File > New Project > ASP.NET MVC 5 Empty Project, Call it “HelloWorldReact” > OK
	2. Install React.js by running following command in the Package Manager Console
		Install-Package react.js
		It will add react javascript files in Scripts folder.
	3. Similarly Install ReactJS.NET:
		Install-Package React.Web.Mvc4
		It will add react library references in the project.
	4. Add MVC5 Empty Controller (HomeController.cs), Add View of Index method without Model.
		Hello World
	5. Add new folder jsx in Scripts folder, Create HelloWorld.jsx file and add following content:
	var HelloWorld = React.createClass({
		render: function(){
			return (
				<div>Hello {this.props.name}</div>
				);
		}
	}); 
	React.render( <HelloWorld name="World" />, document.getElementById('container'));

	6. Add jquery, react and jsx references in the view and add a container to display text. Here is the content of Index view:
	@{
		ViewBag.Title = "Index";
	}
	 
	<h2 id="container"></h2>
	 
	<script src="~/Scripts/jquery-1.10.2.min.js"></script>
	<script src="~/Scripts/react/react-0.12.2.min.js"></script>
	<script src="~/Scripts/jsx/HelloWorld.jsx"></script>

B.Server-side React with ASP.NET
	http://techbrij.com/react-js-seo-server-side-asp-net
	1,2,3: Create project & include reactjs
	4. Add “MVC5 Empty Controller” (HomeController.cs), replace the content of Index method with following and add View.
	public ActionResult Index()
       {   
           var employees = new[]{
                   new  {id= "1", name= "John", department= "IT", phone= "555-1212"},
                   new {id="2", name= "Akash", department= "Sales", phone= "555-1213"},
                   new  {id= "3", name= "Suman", department= "HR", phone= "123-456"}
           };
           return View(employees);
       }
	   
	5. Add a javascript file “Grid.jsx” in Scripts folder and add following content:
	var Cell = React.createClass({   
		render: function () {
			var data = this.props.data;
			return <div className="cell">{this.props.data}</div>
		}
	});
	 
	var Row = React.createClass({
		render: function () {
			return (<div className="row">
				<Cell data={this.props.data.name} />
				<Cell data={this.props.data.department} />
				<Cell data={this.props.data.phone} />
			</div>);
		}
	});
	var Grid = React.createClass({
		render: function () {
		var headerRow = <div className="row">
				<Cell data="Name" />
				<Cell data="Department" />
				<Cell data="Phone" />
			</div>;
	 
			var rows = this.props.data.map(function (rowData, index) {
				return <Row key={index} data={rowData}>Row</Row>;
			});
			return <div className="table">{headerRow}{rows}</div>;
		}
	});

	6. Open App_Start\ReactConfig.cs to reference Grid components:
	public static class ReactConfig
    {
        public static void Configure()
        {
            ReactSiteConfiguration.Configuration = new ReactSiteConfiguration()
                .AddScript("~/Scripts/Grid.jsx");
        }
    }
	7. Open Index View and call Html.React
	<h2>React Demo:</h2> 
	@Html.React("Grid", new
	{
		data = Model
	})
	 
	<script src="~/Scripts/react/react-0.12.2.min.js"></script>
	<script src="~/Scripts/Grid.jsx"></script>
	@Html.ReactInitJavaScript()
======================================================================	
