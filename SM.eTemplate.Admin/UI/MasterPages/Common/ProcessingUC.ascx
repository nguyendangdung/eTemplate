<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProcessingUC.ascx.cs"
    Inherits="SM.eTemplate.UI.MasterPages.Common.ProcessingUC" %>
<div id="processing" class="processing">
    <table border="0" width="100%">
        <col width="40" />
        <col />
        <tr valign="middle">
            <td align="right">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/loading.gif" Width="25" />
            </td>
            <td>
                Đang xử lý...
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript" language="javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    function BeginRequestHandler(sender, args) {
        ActivateAlertDiv('visible');
    }
    function EndRequestHandler(sender, args) {
        ActivateAlertDiv('hidden');
    }
    function ActivateAlertDiv(visstring) {
        var adiv = $get('processing');
        try {
            adiv.style.top = screen.height - 175 + window.pageYOffset + 'px'; //  - window.pageYOffset;
            adiv.style.left = screen.width - 235 + 'px';
        }
        catch (e) {
        }
        adiv.style.visibility = visstring;
    }
</script>
