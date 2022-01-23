<px:PXTabItem Text="Caches">
    <Template>
        <px:PXFormView Height="500" Caption="Caches" CaptionVisible="False" DataMember="RolesInCaches" runat="server" ID="frmRolesInCaches">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" Height="300" runat="server" ID="grdRolesInCaches">
                    <Levels>
                        <px:PXGridLevel DataMember="RolesInCaches">
                            <Columns>
                                <px:PXGridColumn DataField="ScreenID" Width="96"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Cachetype" Width="280"></px:PXGridColumn>
                            </Columns>
                        </px:PXGridLevel>
                    </Levels>
                    <AutoSize MinHeight="200" MinWidth="200" Container="Parent"></AutoSize>
                    <AutoSize MinHeight="200"></AutoSize>
                    <AutoSize MinWidth="200"></AutoSize>
                    <ActionBar ActionsVisible="True">
                        <Actions>
                            <AddNew Enabled="False"></AddNew>
                            <Delete Enabled="False"></Delete>
                            <EditRecord Enabled="False"></EditRecord>
                            <Save Enabled="False"></Save>
                        </Actions>
                        <CustomItems>
                            <px:PXToolBarButton Text="Cache History"></px:PXToolBarButton>
                        </CustomItems>
                    </ActionBar>
                    <AutoCallBack>
                        <Behavior RepaintControlsIDs="grdRoleVersions"></Behavior>
                    </AutoCallBack>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>