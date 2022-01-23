<px:PXTabItem Text="History">
    <Template>
        <px:PXFormView Width="500" runat="server" ID="frmSitemapVersions" DataMember="SitemapVersions">
            <Template>
                <px:PXGrid SkinID="Details" Height="300" runat="server" ID="grdSitemapVersions">
                    <Levels>
                        <px:PXGridLevel DataMember="SitemapVersions">
                            <!--#include file="~\Pages\AK\Includes\Grid_History.inc"-->
                            <Columns>
                                <px:PXGridColumn DataField="Title" Width="280"></px:PXGridColumn>
                            </Columns>
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