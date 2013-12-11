﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataAccessDemo.aspx.cs" Inherits="Labs.DataAccess.Web.DataAccessDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
        * {
            font-family: arial; 
        }
        
         .searchCriteria {
             background-color: lightgoldenrodyellow;
             padding-top: 10px;
             padding-bottom: 10px;
             font-size: larger;
         }
        .searchCriteria input {
            margin-left: 10px;
            margin-right: 30px;
        }
        .searchResult {
            
        }
        .searchLabel {
            float: left;
            width: 200px;
        }
        .searchValue {
            
        }
        .searchNoHit {
            color: darkred;
            font-style: oblique;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        
        <div class="searchCriteria">
             Enter user id: <asp:TextBox runat="server" ID="txtUserId"></asp:TextBox>
            <asp:Button runat="server" ID="btnSearchUsingAdo" Text="ADO.NET search" OnClick="btnSearchUsingAdo_OnClick"/>
        </div>

        <div class="searchResult">
            <h1>Searchresult</h1>
            
            <asp:PlaceHolder runat="server" ID="searchResultHit" Visible="False">
                <div class="searchLabel">Id:</div>
                <div class="searchValue"><asp:TextBox runat="server" ID="txtSearchResult_UserId" /></div>

                <div class="searchLabel">Firstname:</div>
                <div class="searchValue"><asp:TextBox runat="server" ID="txtSearchResult_Firstname" /></div>

                <div class="searchLabel">Lastname:</div>
                <div class="searchValue"><asp:TextBox runat="server" ID="txtSearchResult_Lastname" /></div>

                <div class="searchLabel">Email:</div>
                <div class="searchValue"><asp:TextBox runat="server" ID="txtSearchResult_Email" /></div>
            </asp:PlaceHolder>
            
            <asp:PlaceHolder runat="server" ID="searchResultNoHit" Visible="False">
                <div class="searchNoHit">
                    Doh! No such user found... 
                </div>
            </asp:PlaceHolder>
            
        </div>
    </form>
</body>
</html>
