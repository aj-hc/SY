<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="RuRo.Web.BasedInfo.Show" Title="显示页" %>
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
		PatientName
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPatientName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IPSeqNoText
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblIPSeqNoText" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PatientCardNo
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPatientCardNo" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SexFlag
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSexFlag" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Birthday
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBirthday" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BloodTypeFlag
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBloodTypeFlag" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Phone
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPhone" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ContactPhone
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblContactPhone" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ContactPerson
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblContactPerson" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		NativePlace
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblNativePlace" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RegisterSeqNO
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRegisterSeqNO" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PatientID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPatientID" runat="server"></asp:Label>
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
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




