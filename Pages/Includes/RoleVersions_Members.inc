<px:PXTabItem Text="Members">
    <Template>
        <px:PXFormView Height="500" Caption="Members" CaptionVisible="False" DataMember="RolesInMembers" runat="server" ID="frmRolesInMembers">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" Height="300" runat="server" ID="grdRolesInMembers">
                    <Levels>
                        <px:PXGridLevel DataMember="RolesInMembers">
                            <Columns>
                                <px:PXGridColumn DataField="ScreenID" Width="96"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Cachetype" Width="280"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Membername" Width="280"></px:PXGridColumn>
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
                            <px:PXToolBarButton Text="Member History"></px:PXToolBarButton>
                        </CustomItems>
                    </ActionBar>
                    <AutoSize MinHeight="200" MinWidth="200" Container="Parent"></AutoSize>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>