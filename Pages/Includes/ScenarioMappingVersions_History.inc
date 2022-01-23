<px:PXTabItem Text="History">
    <Template>
        <px:PXFormView Height="500" DataMember="ScenarioMappingVersions" Caption="Scenario Mapping History" CaptionVisible="False" runat="server" ID="frmScenaroMappingHistory">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" SkinID="Details" Height="300" runat="server" ID="grdScenarioMappingVersions">
                    <Levels>
                        <px:PXGridLevel DataMember="ScenarioMappingVersions">
                            <!--#include file="~\Pages\AK\Includes\Grid_History.inc"-->
                            <Columns>
                                <px:PXGridColumn DataField="ScreenID" Width="96"></px:PXGridColumn>
                                <px:PXGridColumn DataField="GraphName" Width="250"></px:PXGridColumn>
                            </Columns>
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar ActionsVisible="True">
                        <Actions>
                            <AddNew Enabled="False"></AddNew>
                            <Delete Enabled="False"></Delete>
                            <EditRecord Enabled="False"></EditRecord>
                            <Save Enabled="False"></Save>
                        </Actions>
                        <CustomItems>
                            <px:PXToolBarButton Text="Compare"></px:PXToolBarButton>
                        </CustomItems>
                    </ActionBar>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>