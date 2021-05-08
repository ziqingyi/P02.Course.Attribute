using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using P37.Course.Web.Core.Models;

namespace P38.Course.LayUI.WebApi.Controllers
{
    public class SystemController : ApiController
    {
        [Route("api/System/GetMenuList")]
        public string GetMenuList()
        {
            AjaxApiModel<MenuInfo> result = new AjaxApiModel<MenuInfo>();
            List<MenuInfo> menus = new List<MenuInfo>()
            {
                new MenuInfo()
                {
                    MenuGuid = Guid.NewGuid(),
                    MenuName = "Menu",
                    Ico = "layui-icon-home",
                    Submenu = new List<MenuInfo>()
                    {
                        new MenuInfo()
                        {
                            MenuGuid = Guid.NewGuid(),
                            MenuName = "SubMenu1",
                            Ico = "layui-icon-code-circle"
                        },
                        new MenuInfo()
                        {
                            MenuGuid = Guid.NewGuid(),
                            MenuName = "SubMenu2",
                            Ico = "layui-icon-engine"
                        }
                    }
                },

                new MenuInfo()
                {
                    MenuGuid=Guid.NewGuid(),
                    MenuName="System",
                    Ico="layui-icon-component",
                    Submenu=new List<MenuInfo>(){
                        new MenuInfo(){
                            MenuGuid=Guid.NewGuid(),
                            MenuName="User Management",
                            Ico="layui-icon-username",
                            Url="Userview.html"
                        },
                        new MenuInfo(){
                            MenuGuid=Guid.NewGuid(),
                            MenuName="Menu Management",
                            Ico="layui-icon-senior",
                            Url="MenuView.html"
                        },
                        new MenuInfo(){
                            MenuGuid=Guid.NewGuid(),
                            MenuName="Picture Management",
                            Ico="layui-icon-template",
                            Url="FileUpload.html"
                        },
                        new MenuInfo(){
                            MenuGuid=Guid.NewGuid(),
                            MenuName="Picture Lazy Loading",
                            Ico="layui-icon-component",
                            Url="lazyImage.html"
                        },
                        new MenuInfo(){
                            MenuGuid=Guid.NewGuid(),
                            MenuName="Carousel",
                            Ico="layui-icon-component",
                            Url="WheelPlanting.html"
                        }
                    }

                }
            };

            result.Data = menus;
            result.Result = true;
            string jsonMenu = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            return jsonMenu;
        }

        [Route("api/System/GetNavigationBarList")]
        public string GetNavigationBarList(int nav)
        {
            AjaxApiModel<MenuInfo> result = new AjaxApiModel<MenuInfo>();
            List<MenuInfo> menus = new List<MenuInfo>()
            {
                new MenuInfo(){
                    MenuGuid=Guid.NewGuid(),
                    MenuName="Console",
                },
                new MenuInfo(){
                    MenuGuid=Guid.NewGuid(),
                    MenuName="Product Management",
                },
                new MenuInfo(){
                    MenuGuid=Guid.NewGuid(),
                    MenuName="Users",
                },
                new MenuInfo(){
                    MenuGuid=Guid.NewGuid(),
                    MenuName="Other Systems",
                    Ico="layui-icon-component",
                    Submenu=new List<MenuInfo>(){
                        new MenuInfo(){
                            MenuGuid=Guid.NewGuid(),
                            MenuName="Mail Management"
                        },
                        new MenuInfo(){
                            MenuGuid=Guid.NewGuid(),
                            MenuName="Message Management"
                        },
                        new MenuInfo(){
                            MenuGuid=Guid.NewGuid(),
                            MenuName="Authorization Management"
                        }
                    }
                }
            };
            result.Result = true;
            result.Data = menus;
            string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            return jsonResult;
        }

        [HttpGet]
        [Route("api/System/GetNavigationBarList")]
        public string GetTreeList(string random)
        {
            AjaxApiModel<TreeResultData> result = new AjaxApiModel<TreeResultData>();
            List<TreeResultData> treeList = new List<TreeResultData>()
            {
                new TreeResultData(){
                    Id=Guid.NewGuid(),
                    Title="TreeNode 1",
                    Href=null,
                    Disabled=false,
                    Children=new List<TreeResultData>(){
                        new TreeResultData(){
                            Id=Guid.NewGuid(),
                            Title="TreeNode1-1",
                            Href="http://www.google.com",
                            Disabled=false
                        },
                        new TreeResultData(){
                            Id=Guid.NewGuid(),
                            Title="TreeNode1-2",
                            Href="http://www.google.com",
                            Disabled=false
                        }

                    }
                },
                new TreeResultData(){
                    Id=Guid.NewGuid(),
                    Title="TreeNode2",
                    Href=null,
                    Disabled=false,
                    Children=new List<TreeResultData>(){
                        new TreeResultData(){
                            Id=Guid.NewGuid(),
                            Title="TreeNode2-1",
                            Href="http://www.google.com",
                            Disabled=false
                        },
                        new TreeResultData(){
                            Id=Guid.NewGuid(),
                            Title="TreeNode2-2",
                            Href="http://www.google.com",
                            Disabled=true
                        }
                    }
                }

            };

            result.Result = true;
            result.Data = treeList;
            string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            return jsonResult;

        }


    }
}
/*


{
"Result":true,
"Data":[
{"MenuGuid":"bd67859e-6384-485b-8a12-6d34d2ba90d6","MenuName":"Menu","Ico":"layui-icon-home","Url":null,"IsLeaf":false,"Submenu":[{"MenuGuid":"ed920d71-25d7-4da9-9c82-0eb34575cdb4","MenuName":"SubMenu1","Ico":"layui-icon-code-circle","Url":null,"IsLeaf":false,"Submenu":null},{"MenuGuid":"4da875ce-67c2-4a97-ad61-a3771c2bfbff","MenuName":"SubMenu2","Ico":"layui-icon-engine","Url":null,"IsLeaf":false,"Submenu":null}]},
{
"MenuGuid":"566c5251-986e-4842-9868-c0b69ab00d93","MenuName":"System","Ico":"layui-icon-component","Url":null,"IsLeaf":false,
"Submenu":[{"MenuGuid":"4399029b-339a-4081-bbd3-09e92e625448","MenuName":"User Management","Ico":"layui-icon-username","Url":"Userview.html","IsLeaf":false,"Submenu":null},
			{"MenuGuid":"87c0be35-730d-40db-a4e3-bfdd2bd8ddcf","MenuName":"Menu Management","Ico":"layui-icon-senior","Url":"MenuView.html","IsLeaf":false,"Submenu":null},
			{"MenuGuid":"061cb2e0-b7c2-4142-a86b-59648c09938b","MenuName":"Picture Management","Ico":"layui-icon-template","Url":"FileUpload.html","IsLeaf":false,"Submenu":null},
			{"MenuGuid":"b5a37b53-cd8d-4548-9ae5-91be99b2dde5","MenuName":"Picture Lazy Loading","Ico":"layui-icon-component","Url":"lazyImage.html","IsLeaf":false,"Submenu":null},
			{"MenuGuid":"8bce7f75-8de6-459c-ae08-8ca5eb580da7","MenuName":"Carousel","Ico":"layui-icon-component",
			"Url":"WheelPlanting.html","IsLeaf":false,"Submenu":null}]
}
],
"Message":null
}


{"Result":true,
"Data":
[
{"MenuGuid":"38696eaf-b795-449b-88c1-2ca1095fac69","MenuName":"Console","Ico":null,"Url":null,"IsLeaf":false,"Submenu":null},
{"MenuGuid":"527910f9-38a9-4950-b678-9212231a4860","MenuName":"Product Management","Ico":null,"Url":null,"IsLeaf":false,"Submenu":null},
{"MenuGuid":"fc0e2fc8-87f2-4a4d-a238-210445e43c8a","MenuName":"Users","Ico":null,"Url":null,"IsLeaf":false,"Submenu":null},
{
"MenuGuid":"46a9aac4-87b1-44f8-a43a-451ddc2e1d0b","MenuName":"Other Systems","Ico":"layui-icon-component","Url":null,"IsLeaf":false,
"Submenu":
[
   {"MenuGuid":"b08c126e-8fb1-46da-8ff0-ad9251424497","MenuName":"Mail Management","Ico":null,"Url":null,"IsLeaf":false,"Submenu":null},
   {"MenuGuid":"5b11a064-fd54-4c19-a03e-0be907f90096","MenuName":"Message Management","Ico":null,"Url":null,"IsLeaf":false,"Submenu":null},
   {"MenuGuid":"bdc5a976-35b8-4416-9f26-9281e260444b","MenuName":"Authorization Management","Ico":null,"Url":null,"IsLeaf":false,"Submenu":null}
]
}
],
"Message":null}








*/
