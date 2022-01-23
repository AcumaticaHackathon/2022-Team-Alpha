<px:PXTabItem Text="Groups">
<Template>
    <px:PXFormView Width="500" Caption="Attribute Groups" CaptionVisible="False" runat="server" ID="frmAttributeGroups" DataMember="AttributeGroups">
        <Template>
            <px:PXGrid Height="300" SkinID="Details" runat="server" ID="grdAttributeGroups">
                <Levels>
                    <px:PXGridLevel DataMember="AttributeGroups">
                        <Columns>
                            <px:PXGridColumn DataField="EntityClassID" Width="140"></px:PXGridColumn>
                            <px:PXGridColumn DataField="EntityType" Width="280"></px:PXGridColumn>
                        </Columns>
                    </px:PXGridLevel>
                </Levels>
                <ActionBar>
                    <Actions>
                        <AddNew Enabled="False"></AddNew>
                    </Actions>
                    <CustomItems>
                        <px:PXToolBarButton Text="Group History"></px:PXToolBarButton>
                    </CustomItems>
                </ActionBar>
                <ActionBar>
                    <Actions>
                        <Delete Enabled="False"></Delete>
                    </Actions>
                </ActionBar>
            </px:PXGrid>
        </Template>
    </px:PXFormView>
</Template>
</px:PXTabItem>