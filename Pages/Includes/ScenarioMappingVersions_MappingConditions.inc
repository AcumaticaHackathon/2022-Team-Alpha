<px:PXTabItem Text="Mapping Conditions">
    <Template>
        <px:PXFormView Height="500" DataMember="ScenarioMappingConditions" Caption="Mapping Conditions" CaptionVisible="False" runat="server" ID="frmScenarioMappingConditions">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" Height="300" runat="server" ID="grdScenarioMappingConditions">
                    <Levels>
                        <px:PXGridLevel DataMember="ScenarioMappingConditions">
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