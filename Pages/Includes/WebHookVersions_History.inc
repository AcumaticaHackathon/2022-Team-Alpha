<px:PXTabItem Text="History">
    <Template>
        <px:PXFormView Width="500" runat="server" ID="frmWebHookVersions" DataMember="WebHookVersions">
            <Template>
                <px:PXGrid SkinID="Details" runat="server" ID="grdWebHookVersions" Height="300">
                    <Levels>
                        <px:PXGridLevel DataMember="WebHookVersions">
                             <!--#include file="~\Pages\AK\Includes\Grid_History.inc"-->
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar>
                        <CustomItems>
                            <px:PXToolBarButton Text="Compare"></px:PXToolBarButton>
                        </CustomItems>
                        <Actions>
                            <AddNew Enabled="False"></AddNew>
                            <Delete Enabled="False"></Delete>
                            <EditRecord Enabled="False"></EditRecord>
                        </Actions>
                    </ActionBar>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>