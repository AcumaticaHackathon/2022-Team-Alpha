<px:PXTabItem Text="Import Conditions">
    <Template>
        <px:PXFormView Height="500" DataMember="ScenarioImportConditions" Caption="Import Conditions" CaptionVisible="False" runat="server" ID="frmScenarioImportConditions">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" Height="300" runat="server" ID="grdScenarioImportConditions">
                    <Levels>
                        <px:PXGridLevel DataMember="ScenarioImportConditions">
                            <Columns>
                                <px:PXGridColumn DataField="ObjectName" Width="250"></px:PXGridColumn>
                                <px:PXGridColumn DataField="FieldName" Width="250"></px:PXGridColumn>
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
                            <px:PXToolBarButton Text="Condition History"></px:PXToolBarButton>
                        </CustomItems>
                    </ActionBar>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>