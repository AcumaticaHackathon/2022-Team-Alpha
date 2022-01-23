<px:PXTabItem Text="Filters">
    <Template>
        <px:PXFormView Width="500" DataMember="GIFilters" runat="server" ID="frmGIFilters" Caption="GI Filters" CaptionVisible="False">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" SkinID="Details" Height="300" runat="server" ID="grdGIFilters">
                    <Levels>
                        <px:PXGridLevel DataMember="GIFilters">
                            <Columns>
                                <px:PXGridColumn DataField="Name" Width="280"></px:PXGridColumn>
                                <px:PXGridColumn DataField="FieldName" Width="280"></px:PXGridColumn>
                            </Columns>
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar ActionsVisible="True">
                        <CustomItems>
                            <px:PXToolBarButton Text="Filter History"></px:PXToolBarButton>
                        </CustomItems>
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
                    </ActionBar>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>