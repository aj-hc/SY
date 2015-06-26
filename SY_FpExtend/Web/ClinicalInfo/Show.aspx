<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="RuRo.Web.ClinicalInfo.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblid" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DiagnoseTypeFlag
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDiagnoseTypeFlag" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DiagnoseDateTime
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDiagnoseDateTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RegisterID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRegisterID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		InPatientID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblInPatientID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ICDCode
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblICDCode" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		DiseaseName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDiseaseName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Description
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDescription" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




