<px:PXTabItem Text="History">
    <Template>
        <px:PXFormView Width="500" runat="server" ID="frmDashboardVersions" DataMember="DashboardVersions">
            <Template>
                <px:PXGrid Height="300" SkinID="Details" runat="server" ID="grdDashboardHistory">
                    <Levels>
                        <px:PXGridLevel DataMember="DashboardVersions">
                            <!--#include file="~\Pages\AK\Includes\Grid_History.inc"-->
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