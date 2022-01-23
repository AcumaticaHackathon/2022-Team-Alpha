<px:PXTabItem Text="Graphs">
    <Template>
        <px:PXFormView Height="500" Caption="Graphs" CaptionVisible="False" DataMember="RolesInGraphs" runat="server" ID="frmRolesInGraphs">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" Height="300" runat="server" ID="grdRolesInGraphs">
                    <Levels>
                        <px:PXGridLevel DataMember="RolesInGraphs">
                            <Columns>
                                <px:PXGridColumn DataField="ScreenID" Width="96"></px:PXGridColumn>
                            </Columns>
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar ActionsVisible="True">
                        <Actions>
                            <AddNew Enabled="False"></AddNew>
                            <Delete Enabled="False"></Delete>
                            <Save Enabled="False"></Save>
                        </Actions>
                        <CustomItems>
                            <px:PXToolBarButton Text="Graph History"></px:PXToolBarButton>
                        </CustomItems>
                    </ActionBar>
                    <AutoSize MinHeight="200" MinWidth="200" Container="Parent"></AutoSize>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>