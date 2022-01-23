<px:PXTabItem Text="Tables">
    <Template>
        <px:PXFormView Width="500" runat="server" ID="frmGITables" Caption="Tables" CaptionVisible="False" DataMember="GITables">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" SkinID="Details" Height="300" runat="server" ID="grdGITables">
                    <Levels>
                        <px:PXGridLevel DataMember="GITables">
                            <Columns>
                                <px:PXGridColumn DataField="Alias" Width="280"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Name" Width="280"></px:PXGridColumn>
                            </Columns>
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar ActionsVisible="True">
                        <Actions>
                            <AddNew Enabled="False"></AddNew>
                        </Actions>
                        <Actions>
                            <Delete Enabled="False"></Delete>
                        </Actions>
                        <Actions>
                            <EditRecord Enabled="False"></EditRecord>
                        </Actions>
                        <Actions>
                            <Save Enabled="False"></Save>
                        </Actions>
                        <CustomItems>
                            <px:PXToolBarButton Text="Table History"></px:PXToolBarButton>
                        </CustomItems>
                    </ActionBar>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>