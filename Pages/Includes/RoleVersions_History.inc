<px:PXTabItem Text="History">
    <Template>
        <px:PXFormView Height="500" CaptionVisible="False" DataMember="RoleVersions" runat="server" ID="frmRoleHistory" Caption="Role History">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" SkinID="Details" Height="300" runat="server" ID="grdRoleVersions">
                    <Levels>
                        <px:PXGridLevel DataMember="RoleVersions">
                            <!--#include file="~\Pages\AK\Includes\Grid_History.inc"-->
                            <Columns>
                                <px:PXGridColumn DataField="Rolename" Width="220"></px:PXGridColumn>
                                <px:PXGridColumn DataField="ApplicationName" Width="180"></px:PXGridColumn>
                            </Columns>
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar>
                        <CustomItems>
                            <px:PXToolBarButton Text="Compare"></px:PXToolBarButton>
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