using System;
using System.Collections.Generic;
using ClassLibraryExample.Core.Pojo;
using Foundation;
using MvvmCross.Base;
using MvvmCross.Binding.Extensions;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace Blank.PhotosTableView
{
    public class PhotosTableViewSource : MvxCollectionViewSource
    {
        public PhotosTableViewSource(UICollectionView collectionView) : base(collectionView)
        {
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var item = ((IEnumerable<HitModel>) ItemsSource).ElementAt(indexPath.Row);

            var photoCell = GetOrCreateCellFor(collectionView, indexPath, item);

            return photoCell;
        }

        protected override UICollectionViewCell GetOrCreateCellFor(UICollectionView collectionView,
            NSIndexPath indexPath, object item)
        {
            var cell = collectionView.DequeueReusableCell(PhotosCell.Key, indexPath) as PhotosCell;

            var singleTap = new UITapGestureRecognizer(s => { SelectionChangedCommand.Execute(item); });

            cell.UserInteractionEnabled = true;
            cell.AddGestureRecognizer(singleTap);

            if (cell is IMvxDataConsumer bindable)
            {
                bindable.DataContext = item;
            }

            return cell;
        }

        public override bool ShouldHighlightItem(UICollectionView collectionView, NSIndexPath indexPath)
        {
            return false;
        }
    }
}