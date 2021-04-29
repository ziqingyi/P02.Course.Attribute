using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P37.Course.Web.Core.Models;

namespace P38.Course.LayUI.WebApi.Controllers
{
    public class SystemController : Controller
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
                    id=Guid.NewGuid(),
                    title="TreeNode 1",
                    href=null,
                    disabled=false,
                    children=new List<TreeResultData>(){
                        new TreeResultData(){
                            id=Guid.NewGuid(),
                            title="TreeNode1-1",
                            href="http://www.google.com",
                            disabled=false
                        },
                        new TreeResultData(){
                            id=Guid.NewGuid(),
                            title="TreeNode1-2",
                            href="http://www.google.com",
                            disabled=false
                        }

                    }
                },
                new TreeResultData(){
                    id=Guid.NewGuid(),
                    title="TreeNode2",
                    href=null,
                    disabled=false,
                    children=new List<TreeResultData>(){
                        new TreeResultData(){
                            id=Guid.NewGuid(),
                            title="TreeNode2-1",
                            href="http://www.google.com",
                            disabled=false
                        },
                        new TreeResultData(){
                            id=Guid.NewGuid(),
                            title="TreeNode2-2",
                            href="http://www.google.com",
                            disabled=true
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