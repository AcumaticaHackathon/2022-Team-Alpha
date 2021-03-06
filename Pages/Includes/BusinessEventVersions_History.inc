<px:PXTabItem Text="History">
    <Template>
        <px:PXFormView Width="500" DataMember="BusinessEventVersions" Caption="Biz Event History" CaptionVisible="False" runat="server" ID="frmtBusEventHistory">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" SkinID="Details" Height="300" runat="server" ID="grdBusEventVersions">
                    <Levels>
                        <px:PXGridLevel DataMember="BusinessEventVersions">
                            <!--#include file="~\Pages\AK\Includes\Grid_History.inc"-->
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar ActionsVisible="True">
                        <CustomItems>
                            <px:PXToolBarButton Text="Compare"></px:PXToolBarButton>
                        </CustomItems>
                        <Actions>
                            <AddNew Enabled="False"></AddNew>
                            <Delete Enabled="False"></Delete>
                            <EditRecord Enabled="False"></EditRecord>
                            <Save Enabled="False"></Save>
                        </Actions>
                    </ActionBar>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>