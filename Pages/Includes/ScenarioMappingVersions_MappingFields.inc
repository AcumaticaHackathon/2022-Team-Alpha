<px:PXTabItem Text="Mapping Fields">
    <Template>
        <px:PXFormView Height="500" DataMember="ScenarioMappingFields" Caption="Scenario Mapping Fields" CaptionVisible="False" runat="server" ID="frmScenarioMappingFields">
            <Template>
                <px:PXGrid Height="300" runat="server" ID="grdScenarioMappingFields">
                    <Levels>
                        <px:PXGridLevel DataMember="ScenarioMappingFields">
                            <Columns>
                                <px:PXGridColumn DataField="ObjectName" Width="250"></px:PXGridColumn>
                                <px:PXGridColumn DataField="FieldName" Width="280"></px:PXGridColumn>
                            </Columns>
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar>
                        <CustomItems>
                            <px:PXToolBarButton Text="Field History"></px:PXToolBarButton>
                        </CustomItems>
                    </ActionBar>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>