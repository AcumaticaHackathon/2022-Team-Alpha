<px:PXTabItem Text="Sorts">
    <Template>
        <px:PXFormView Width="500" Caption="Sorts" CaptionVisible="False" DataMember="GISorts" runat="server" ID="frmGISorts">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" SkinID="Details" Height="300" runat="server" ID="grdGISorts">
                    <Levels>
                        <px:PXGridLevel DataMember="GISorts">
                            <Columns>
                                <px:PXGridColumn DataField="DataFieldName" Width="70"></px:PXGridColumn>
                                <px:PXGridColumn DataField="SortOrder" Width="70"></px:PXGridColumn>
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
                            <px:PXToolBarButton Text="Sort History"></px:PXToolBarButton>
                        </CustomItems>
                    </ActionBar>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>