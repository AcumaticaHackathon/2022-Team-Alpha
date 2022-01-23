<px:PXTabItem Text="Options">
<Template>
    <px:PXFormView Width="500" DataMember="AttributeDetails" Caption="Attribute Detail" CaptionVisible="False" runat="server" ID="frmAttributeDetail">
        <Template>
            <px:PXGrid SkinID="Details" Height="300" runat="server" ID="grdAttributeDetails">
                <Levels>
                    <px:PXGridLevel DataMember="AttributeDetails">
                        <Columns>
                            <px:PXGridColumn DataField="ValueID" Width="120"></px:PXGridColumn>
                            <px:PXGridColumn DataField="Description" Width="220"></px:PXGridColumn>
                        </Columns>
                    </px:PXGridLevel>
                </Levels>
                <ActionBar>
                    <CustomItems>
                        <px:PXToolBarButton Text="Option History"></px:PXToolBarButton>
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