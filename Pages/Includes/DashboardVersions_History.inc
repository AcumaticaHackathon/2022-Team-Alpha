<px:PXTabItem Text="History">
    <Template>
        <px:PXFormView Width="500" runat="server" ID="frmDashboardVersions" DataMember="DashboardVersions">
            <Template>
                <px:PXGrid Height="300" SkinID="Details" runat="server" ID="grdDashboardHistory">
                    <Levels>
                        <px:PXGridLevel DataMember="DashboardVersions">
                            <Columns>
                                <px:PXGridColumn DataField="Selected" Width="60"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Version" Width="70"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Name" Width="70"></px:PXGridColumn>
                                <px:PXGridColumn DataField="ActionName" Width="70"></px:PXGridColumn>
                                <px:PXGridColumn DataField="CreatedDateTime" Width="90"></px:PXGridColumn>
                            </Columns>
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar>
                        <CustomItems>
                            <px:PXToolBarButton Text="Compare"></px:PXToolBarButton>
                        </CustomItems>
                        <Actions>
                            <AddNew Enabled="False"></AddNew>
                        </Actions>
                        <Actions>
                            <Delete Enabled="False"></Delete>
                        </Actions>
                    </ActionBar>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>