<px:PXTabItem Text="Parameters">
    <Template>
        <px:PXFormView Width="500" runat="server" ID="frmDashboardParameters" Caption="Parameters" DataMember="DashboardParameters" CaptionVisible="False">
            <Template>
                <px:PXGrid SkinID="Details" runat="server" ID="grdDashboardParameters" Height="300">
                    <Levels>
                        <px:PXGridLevel DataMember="DashboardParameters">
                            <Columns>
                                <px:PXGridColumn DataField="Name" Width="280"></px:PXGridColumn>
                                <px:PXGridColumn DataField="LineNbr" Width="70"></px:PXGridColumn>
                            </Columns>
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar>
                        <Actions>
                            <AddNew Enabled="False"></AddNew>
                            <Delete Enabled="False"></Delete>
                            <EditRecord Enabled="False"></EditRecord>
                            <Save Enabled="False"></Save>
                        </Actions>
                        <CustomItems>
                            <px:PXToolBarButton Text="Parameter History"></px:PXToolBarButton>
                        </CustomItems>
                    </ActionBar>
                    <AutoCallBack ActiveBehavior="False"></AutoCallBack>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>