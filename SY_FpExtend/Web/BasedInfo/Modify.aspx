<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="RuRo.Web.BasedInfo.Modify" Title="修改页" %>
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
		<asp:label id="lblid" runat="server"></asp:label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PatientName
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPatientName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		IPSeqNoText
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtIPSeqNoText" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PatientCardNo
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPatientCardNo" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SexFlag
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSexFlag" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Birthday
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtBirthday" runat="server" Width="70px"  onfocus="setday(this)"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		BloodTypeFlag
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtBloodTypeFlag" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Phone
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPhone" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ContactPhone
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtContactPhone" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ContactPerson
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtContactPerson" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		NativePlace
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtNativePlace" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RegisterSeqNO
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRegisterSeqNO" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PatientID
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPatientID" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		RegisterID
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtRegisterID" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		InPatientID
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtInPatientID" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
</table>
<script src="/js/calendar1.js" type="text/javascript"></script>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click" class="inputbutton" onmouseover="this.className='inputbutton_hover'"
                    onmouseout="this.className='inputbutton'"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>

