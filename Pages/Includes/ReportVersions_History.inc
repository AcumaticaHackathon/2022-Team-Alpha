<px:PXTabItem Text="History">
    <Template>
        <px:PXFormView Width="500" Caption="Report History" CaptionVisible="False" DataMember="ReportVersions" runat="server" ID="frmReportHistory">
            <Template>
                <px:PXGrid Height="300" SkinID="Details" FilesIndicator="False" NoteIndicator="False" SyncPosition="True" runat="server" ID="grdReportHistory">
                    <Levels>
                        <px:PXGridLevel DataMember="ReportVersions">
                           <!--#include file="~\Pages\AK\Includes\Grid_History.inc"-->
                        </px:PXGridLevel>
                    </Levels>
                    <AutoCallBack ActiveBehavior="True" Target="frmCurrentReportVersion" Command="Refresh">
                        <Behavior RepaintControlsIDs="txtReportVersion"></Behavior>
                    </AutoCallBack>
                    <AutoCallBack Target="frmReportCurrentVersion"></AutoCallBack>
                    <CallbackCommands>
                        <Refresh RepaintControlsIDs="txtReportVersion"></Refresh>
                    </CallbackCommands>
                    <ActionBar>
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