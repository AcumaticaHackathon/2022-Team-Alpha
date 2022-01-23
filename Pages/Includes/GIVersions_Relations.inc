<px:PXTabItem Text="Relations">
<Template>
    <px:PXFormView Width="500" runat="server" ID="frmGIRelations" Caption="Relations" CaptionVisible="False" DataMember="GIRelations">
        <Template>
            <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" SkinID="Details" Height="300" runat="server" ID="grdGIRelations">
                <Levels>
                    <px:PXGridLevel DataMember="GIRelations">
                        <Columns>
                            <px:PXGridColumn DataField="ParentTable" Width="280"></px:PXGridColumn>
                            <px:PXGridColumn DataField="ChildTable" Width="280"></px:PXGridColumn>
                        </Columns>
                    </px:PXGridLevel>
                </Levels>
                <ActionBar ActionsVisible="True">
                    <CustomItems>
                        <px:PXToolBarButton Text="Relation History"></px:PXToolBarButton>
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