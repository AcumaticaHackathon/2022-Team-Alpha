<px:PXTabItem Text="Widgets">
    <Template>
        <px:PXFormView Width="500" runat="server" ID="frmWidgets" Caption="Widgets" CaptionVisible="False" DataMember="Widgets">
            <Template>
                <px:PXGrid SkinID="Details" runat="server" ID="grdWidgets" Height="300">
                    <Levels>
                        <px:PXGridLevel DataMember="Widgets">
                            <Columns>
                                <px:PXGridColumn DataField="Caption" Width="280"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Type" Width="70"></px:PXGridColumn>
                            </Columns>
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar>
                        <Actions>
                            <AddNew Enabled="False"></AddNew>
                            <Delete Enabled="False"></Delete>
                        </Actions>
                        <CustomItems>
                            <px:PXToolBarButton Text="Widget History"></px:PXToolBarButton>
                        </CustomItems>
                    </ActionBar>
                    <AutoCallBack ActiveBehavior="False"></AutoCallBack>
                    <AutoCallBack Command="Refresh"></AutoCallBack>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>