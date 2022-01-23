<px:PXTabItem Text="History">
    <Template>
        <px:PXFormView Width="500" DataMember="GIVersions" runat="server" ID="frmGIVersions">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" SkinID="Details" Height="300" runat="server" ID="grdGIHistory">
                    <Levels>
                        <px:PXGridLevel DataMember="GIVersions">
                            <!--#include file="~\Pages\AK\Includes\Grid_History.inc"-->
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar>
                        <CustomItems>
                            <px:PXToolBarButton Text="Compare"></px:PXToolBarButton>
                        </CustomItems>
                    </ActionBar>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>