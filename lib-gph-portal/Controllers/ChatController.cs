using sa.gov.libgph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace sa.gov.libgph.Controllers
{
    public class ChatController : SurfaceController
    {
        // GET: Chat
        public ActionResult Index()
        {
            return View();
        }
        List<ChatBotSearchListModel> searchList = new List<ChatBotSearchListModel>();
        List<ChatBotModel> searchResult = new List<ChatBotModel>();
        List<ChatBotModel> chatBotTreeList = new List<ChatBotModel>();
        bool firstNode = false;
        public VPModel SelectedNodeData2(IEnumerable<IPublishedElement> chatBotTree, string selectedNode, int level, int selectedLevel)
        {
            VPModel vpm = new VPModel();


            /*foreach (IPublishedContent ct in chatBotTree)
             {*/
            IPublishedElement selectedOption = null;
            if (selectedNode == "PRVM")
                selectedOption = chatBotTree.Where(c => c.IsVisible()).FirstOrDefault();
            else
                selectedOption = chatBotTree.Where(c => c.IsVisible() && c.Value<string>("title") == selectedNode).FirstOrDefault();


            IEnumerable<IPublishedElement> chatBotLevel2 = null;
            IEnumerable<Link> links = null;
            if ((selectedOption != null && level >= selectedLevel && selectedNode != "PRVM") || (selectedOption != null && selectedNode == "PRVM" && (level == selectedLevel - 2 || selectedLevel == 2)))
            {
                chatBotLevel2 = selectedOption.Value<IEnumerable<IPublishedElement>>("level" + level);
                links = selectedOption.Value<IEnumerable<Link>>("link");
                vpm.relatedLinks = links;
                vpm.iePublishedContent = chatBotLevel2;
                if (selectedNode == "PRVM")
                    if (selectedLevel == 2)
                        vpm.level = selectedLevel;
                    else
                        vpm.level = selectedLevel - 2;
                else
                    vpm.level = level + 1;
                return vpm;



            }
            else
            {
                IPublishedElement nextLevel = chatBotTree.Where(c => c.IsVisible()).FirstOrDefault();
                IEnumerable<IPublishedContent> leveln = nextLevel.Value<IEnumerable<IPublishedContent>>("level" + level);
                if (leveln != null)
                    return SelectedNodeData2(leveln, selectedNode, level + 1, selectedLevel);
            }


            //}

            if (vpm.iePublishedContent == null)
                vpm.level = level;
            return vpm;




        }

        public VPModel SelectedNodeData1(IEnumerable<IPublishedElement> chatBotTree, string selectedNode, int level, int selectedLevel)
        {
            VPModel vpm = new VPModel();


            foreach (IPublishedElement ct in chatBotTree.Where(c => c.IsVisible()))
            {
                IPublishedElement selectedOption = null;
                if (selectedNode == "PRVM")
                    selectedOption = ct;
                else
                    selectedOption = (ct.Value<string>("title") == selectedNode) ? ct : null;


                IEnumerable<IPublishedElement> chatBotLevel2 = null;
                IEnumerable<Link> links = null;
                if ((selectedOption != null && level >= selectedLevel && selectedNode != "PRVM") || (selectedOption != null && selectedNode == "PRVM" && (level == selectedLevel - 2 || selectedLevel == 2)))
                {
                    chatBotLevel2 = selectedOption.Value<IEnumerable<IPublishedElement>>("level" + level);
                    links = selectedOption.Value<IEnumerable<Link>>("link");
                    vpm.relatedLinks = links;
                    vpm.iePublishedContent = chatBotLevel2;
                    if (selectedNode == "PRVM")
                        if (selectedLevel == 2)
                            vpm.level = selectedLevel;
                        else
                            vpm.level = selectedLevel - 2;
                    else
                        vpm.level = level + 1;
                    return vpm;



                }
                else
                {
                    IPublishedElement nextLevel = chatBotTree.Where(c => c.IsVisible()).FirstOrDefault();
                    IEnumerable<IPublishedContent> leveln = nextLevel.Value<IEnumerable<IPublishedContent>>("level" + level);
                    if (leveln != null)
                        return SelectedNodeData1(leveln, selectedNode, level + 1, selectedLevel);
                }


            }

            if (vpm.iePublishedContent == null)
                vpm.level = level;
            return vpm;




        }
        public VPModel SelectedNodeData(IEnumerable<IPublishedElement> chatBotTree, string selectedNode, int level, int selectedLevel, int idx, string nodeId)
        {
            VPModel vpm = new VPModel();

            int nodeIndex = 1;
            string[] nodeIdArr = nodeId.Split('-');
            if (chatBotTree != null)
            {
                foreach (IPublishedElement ct in chatBotTree)
                {
                    if (nodeIndex.ToString() == nodeIdArr[level - 2])
                    {
                        IPublishedElement selectedOption = ct;// chatBotTree.Where(c => c.IsVisible() && c.GetPropertyValue<string>("title") == selectedNode).FirstOrDefault();

                        IEnumerable<IPublishedElement> chatBotLevel2 = null;
                        IEnumerable<Link> links = null;
                        string message = "";
                        if (/*selectedOption != null &&*/ (selectedNode != "PRVM" && level == selectedLevel) || (selectedNode == "PRVM" && (level == selectedLevel - 2 || selectedLevel == 2)))
                        {
                            if (selectedOption != null)
                            {
                                chatBotLevel2 = selectedOption.Value<IEnumerable<IPublishedElement>>("level" + level);
                                message = selectedOption.HasValue("message") ? selectedOption.Value<string>("message") : "";
                                links = selectedOption.Value<IEnumerable<Link>>("link");
                                if (selectedNode == "PRVM")
                                    if (level == 2)
                                        vpm.nodeId = nodeIndex.ToString();
                                    else
                                        vpm.nodeId = nodeId;

                                else
                                    vpm.nodeId = nodeId;
                            }
                            vpm.relatedLinks = links;
                            vpm.iePublishedContent = chatBotLevel2;
                            vpm.message = message;
                            //vpm.level = level + 1;
                            if (selectedNode == "PRVM")
                                if (selectedLevel == 2)
                                    vpm.level = selectedLevel;
                                else
                                    vpm.level = selectedLevel - 1;
                            else
                                vpm.level = level + 1;
                            return vpm;



                        }
                        else
                        {
                            IPublishedElement nextLevel = ct; //chatBotTree.Where(c => c.IsVisible()).FirstOrDefault();
                            IEnumerable<IPublishedElement> leveln = nextLevel.Value<IEnumerable<IPublishedElement>>("level" + level);
                            if (leveln != null)
                                return SelectedNodeData(leveln, selectedNode, level + 1, selectedLevel, idx, nodeId);
                        }
                    }




                    nodeIndex++;

                }

            }

            return vpm;




        }
        public string chatSearchResult(IEnumerable<IPublishedElement> chatBotTree, string selectedNode, int level, int selectedLevel, int idx, string nodeId)
        {

            //VPModel vpm = new VPModel();

            int nodeIndex = 1;
            string[] nodeIdArr = nodeId.Split('-');

            foreach (IPublishedElement ct in chatBotTree)
            {
                if (nodeIndex.ToString() == nodeIdArr[level - 2])
                {
                    IPublishedElement selectedOption = null;// ct;// chatBotTree.Where(c => c.IsVisible() && c.GetPropertyValue<string>("title") == selectedNode).FirstOrDefault();
                    selectedOption = chatBotTree.Where(c => c.IsVisible() && c.Value<string>("title").Contains(selectedNode)).FirstOrDefault();






                    if (level == selectedLevel)
                    {


                        IEnumerable<IPublishedElement> chatBotLevel2 = null;
                        IEnumerable<Link> links = null;
                        string resultTitle = ct.HasValue("title") ? ct.Value<string>("title") : "";
                        string[] resultTitleArr = { resultTitle };
                        //  string[] searchKeys = ct.HasValue("searchKeys")? ct.GetPropertyValue<string[]>("searchKeys"): resultTitleArr;
                        string[] searchKeys = ct.Value<string[]>("searchKeys");

                        chatBotLevel2 = ct.Value<IEnumerable<IPublishedElement>>("level" + level);
                        links = ct.Value<IEnumerable<Link>>("link");

                        if (resultTitle != "")
                        {
                            if (searchKeys != null)
                            {
                                if (searchKeys.Length > 0)
                                {
                                    if (/*resultTitle.Contains(selectedNode) ||*/ checkSearchKeys(searchKeys, selectedNode) /*searchKeys.Contains(selectedNode)*/)
                                    {

                                        ChatBotModel cbm = new ChatBotModel();
                                        cbm.title = resultTitle;
                                        cbm.nodeId = nodeId;
                                        cbm.links = links;
                                        int l = nodeId.Split('-').Length + 1;
                                        cbm.currentLevel = l.ToString();
                                        bool existedNode = false;
                                        foreach (ChatBotModel c in searchResult)
                                        {
                                            if (c.nodeId == cbm.nodeId)
                                            {
                                                existedNode = true;
                                                break;
                                            }
                                        }
                                        if (!existedNode)
                                            searchResult.Add(cbm);
                                    }
                                }
                            }
                        }

                        ChatBotModel cbm1 = new ChatBotModel();
                        cbm1.title = resultTitle;
                        cbm1.nodeId = nodeId;
                        cbm1.links = links;
                        int l1 = nodeId.Split('-').Length + 1;
                        cbm1.currentLevel = l1.ToString();
                        bool existedNode1 = false;
                        foreach (ChatBotModel c in searchResult)
                        {
                            if (c.nodeId == cbm1.nodeId)
                            {
                                existedNode1 = true;
                                break;
                            }
                        }
                        if (!existedNode1)
                            chatBotTreeList.Add(cbm1);

                        if (chatBotLevel2 != null && !firstNode)
                        {
                            ChatBotSearchListModel cbsm = new ChatBotSearchListModel();
                            cbsm.nodeId = nodeId;
                            cbsm.childrenCount = chatBotLevel2.Count();
                            searchList.Add(cbsm);
                        }

                        return "Done";

                        /*

                        if (selectedOption != null)
                        {
                            chatBotLevel2 = selectedOption.GetPropertyValue<IEnumerable<IPublishedContent>>("level" + level);
                            links = selectedOption.GetPropertyValue<RelatedLinks>("link");
                            if (selectedNode == "PRVM")
                                if (level == 2)
                                    chatVpm.nodeId = nodeIndex.ToString();
                                else
                                    chatVpm.nodeId = nodeId;

                            else
                                chatVpm.nodeId = nodeId;
                        }
                        chatVpm.relatedLinks = links;
                        chatVpm.iePublishedContent = chatBotLevel2;
                        //vpm.level = level + 1;
                        if (selectedNode == "PRVM")
                            if (selectedLevel == 2)
                                chatVpm.level = selectedLevel;
                            else
                                chatVpm.level = selectedLevel - 1;
                        else
                            chatVpm.level = level + 1;
                        return chatVpm;
                        */


                    }
                    else
                    {
                        IPublishedElement nextLevel = ct; //chatBotTree.Where(c => c.IsVisible()).FirstOrDefault();
                        IEnumerable<IPublishedElement> leveln = nextLevel.Value<IEnumerable<IPublishedElement>>("level" + level);
                        if (leveln != null)
                            return chatSearchResult(leveln, selectedNode, level + 1, selectedLevel, idx, nodeId);
                    }
                }




                nodeIndex++;

            }

            return "Done";




        }

        public void searchInChatBotTree(IEnumerable<IPublishedElement> chatBotTree, string selectedNode, int selectedLevel, int selectedIndex, string nodeId)
        {
            ChatBotSearchListModel cbs = searchList[0];
            string currentNode = cbs.nodeId;
            int newSelectedLevel = 0;
            if (firstNode)
            {
                chatSearchResult(chatBotTree, selectedNode, 2, selectedLevel, 1, currentNode);
                firstNode = false;
            }
            else
            {
                newSelectedLevel = currentNode.Split('-').Length + 1;
                for (int c = 1; c <= 50; c++)
                {
                    chatSearchResult(chatBotTree, selectedNode, 2, newSelectedLevel + 1, 1, currentNode + "-" + c);
                    //  newIds.Add(nId + "-" + c);
                }
                searchList.Remove(cbs);
            }


            if (searchList.Count() > 0)
                searchInChatBotTree(chatBotTree, selectedNode, selectedLevel, selectedIndex, nodeId);
        }

        public bool checkSearchKeys(string[] searchKeys, string searchString)
        {
            for (int i = 0; i < searchKeys.Length; i++)
            {
                if (searchKeys[i].Trim().Equals(searchString.Trim()))// == searchString)
                {
                    string x = searchKeys[i];
                    return true;
                }
            }
            return false;
        }
        [HttpPost]
        public ActionResult SubmitChatbot(string selectedNode, int selectedLevel, int selectedIndex, string nodeId, string chatType)
        {

            VPModel vm = new VPModel();
            IPublishedContent home = Umbraco.ContentQuery.Content(2518);

            IEnumerable<IPublishedElement> chatBotTree = home.Value<IEnumerable<IPublishedElement>>("chatBotTree");
            // var ncItems = JsonConvert.DeserializeObject<List<object>>(chatBotTree.ToList().to);
            // ConfigurationHelper.Value<string>("my.alias");

            //***************************************************************************//
            if (chatType == "Typing")
            {
                string[] chatKeys = selectedNode.Split(' ');

                List<string> chatKeysList = new List<string>();
                chatKeysList.Add(selectedNode);
                for (int key = 0; key < chatKeys.Length; key++)
                {
                    string chatKeyVal = chatKeys[key].Replace('?', ' ');
                    chatKeyVal = chatKeyVal.Replace('.', ' ');
                    chatKeyVal = chatKeyVal.Replace('_', ' ');
                    chatKeysList.Add(chatKeyVal);
                }

                foreach (string sKey in chatKeysList)
                {
                    for (int cId = 1; cId <= chatBotTree.Count(); cId++)
                    {
                        firstNode = true;
                        ChatBotSearchListModel cbsm = new ChatBotSearchListModel();
                        cbsm.nodeId = cId.ToString();
                        searchList.Add(cbsm);
                        searchInChatBotTree(chatBotTree, sKey /*selectedNode*/, selectedLevel, selectedIndex, nodeId);
                    }
                }

                /*   List<ChatBotSearchListModel> searchList1 = new List<ChatBotSearchListModel>();
                   List<ChatBotModel> searchResult1 = new List<ChatBotModel>();

                   searchList1 = searchList;
                   searchResult1 = searchResult;*/

                vm.chatBotTreeList = chatBotTreeList;
                Session["chatBotTreeList"] = chatBotTreeList;
                if (searchResult.Count() > 0)
                {
                    vm.searchResult = searchResult;
                }
                else if (searchResult.Count() == 0 && selectedNode != "")
                {
                    List<string> res = new List<string>();
                    IEnumerable<IPublishedElement> chatBotAnswers = home.Value<IEnumerable<IPublishedElement>>("chatBotAnswers");
                    foreach (string sKey in chatKeysList)
                    {
                        foreach (IPublishedElement ans in chatBotAnswers)
                        {
                            string answerText = ans.HasValue("answer") ? ans.Value<string>("answer") : "";

                            string[] searchKeys = ans.Value<string[]>("answerKeys");
                            if (searchKeys.Contains(sKey))
                            {
                                if (!res.Contains(answerText))
                                    res.Add(answerText);

                            }
                        }
                    }
                    if (res.Count > 0)
                        vm.chatBotAnswer = res;
                    else


                        vm.notFoundMessage = home.HasValue("notFoundMessage") ? home.Value<string>("notFoundMessage") : "";
                }


            }
            //****************************************************************************//
            else if (chatType == "Click")
            {
                /*  var contentService = Services.ContentService;
                  IContent voteDoc = contentService.GetById(1110);

                  string val = voteDoc.GetValue("chatBotTree").ToString();
                  string s = "\"[";
                  string s1 = "]\"";

                  string newval = val.Replace(s, "[");
                  string newval1 = newval.Replace(s, "[");
                  var ncItems = JsonConvert.DeserializeObject<List<object>>(val.ToString());
                  */
                //      var ncItems1 = JsonConvert.DeserializeObject<List<object>>(newval1.ToString());

                //          JObject json = JObject.Parse(val.ToString());
                //       ncItems.Where()
                //  contentService.SaveAndPublishWithStatus(voteDoc);


                if (selectedNode == "PRVM" && selectedLevel - 1 > 2)
                {
                    vm = SelectedNodeData(chatBotTree, selectedNode, 2, selectedLevel, selectedIndex, nodeId);
                }
                else if (selectedNode != "MN" && selectedNode != "PRVM")

                {
                    //foreach (IPublishedContent ct in chatBotTree)
                    //{
                    /* IEnumerable<IPublishedContent> c = ct.Children();
                     c.ToList().Add(ct);*/
                    vm = SelectedNodeData(chatBotTree, selectedNode, 2, selectedLevel, selectedIndex, nodeId);
                    // }

                }
                else //if (selectedNode == "MN" || (selectedNode == "PRVM" && selectedLevel ==  2))
                {
                    vm.iePublishedContent = chatBotTree;
                    vm.nodeId = "MN";
                    vm.level = 2;
                }
            }
            vm.chatType = chatType;
            return PartialView("/Views/Partials/Chat/_chatBotReturn.cshtml", vm);

        }

        [HttpPost]
        public ActionResult SubmitChatbot1(string selectedNode, string selectedLevel)
        {

            VPModel vm = new VPModel();
            IPublishedContent home = Umbraco.ContentQuery.Content(2518);

            IEnumerable<IPublishedElement> chatBotTree = home.Value<IEnumerable<IPublishedElement>>("chatBotTree");

            if (selectedNode != "MN")
            {

                IPublishedElement selectedOption = chatBotTree.Where(c => c.IsVisible() && c.Value<string>("title") == selectedNode).FirstOrDefault();
                IEnumerable<Link> links = null;
                IEnumerable<IPublishedElement> chatBotLevel2 = null;
                if (selectedOption != null)
                {
                    chatBotLevel2 = selectedOption.Value<IEnumerable<IPublishedElement>>("level2");
                    links = selectedOption.Value<IEnumerable<Link>>("link");
                }
                if (links != null)
                    vm.relatedLinks = links;
                vm.iePublishedContent = chatBotLevel2;
            }
            else
            {
                vm.iePublishedContent = chatBotTree;
            }
            return PartialView("/Views/Partials/jts.gov.sa/_chatBotReturn.cshtml", vm);

        }
    }
}