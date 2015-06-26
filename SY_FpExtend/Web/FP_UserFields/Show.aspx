<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="RuRo.Web.FP_UserFields.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		userFieldId
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbluserFieldId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		obj_id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblobj_id" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		display_name
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbldisplay_name" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		name
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblname" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		type
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lbltype" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		values
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblvalues" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		show
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblshow" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		created_at
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblcreated_at" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		updated_at
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblupdated_at" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		inuse
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblinuse" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




